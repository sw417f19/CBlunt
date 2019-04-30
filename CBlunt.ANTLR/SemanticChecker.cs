using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CBlunt.ANTLR.AutoGeneratedParser;
using System.Reflection;

namespace CBlunt.ANTLR
{
    class SemanticChecker : CBluntBaseVisitor<int>
    {
        private Dictionary<string, VariableProperties> _classScopeVariablesDictionary = new Dictionary<string, VariableProperties>();
        private LinkedList<Dictionary<string, VariableProperties>> _methodScopeLinkedList = new LinkedList<Dictionary<string, VariableProperties>>();

        void SyntaxError(object context, string err)
        {
            var errLine = (int)GetPropertyValue(GetPropertyValue(context, "Start"), "Line");

            Console.WriteLine("Syntax error on line " + errLine + "! " + err);
        }

        public object GetPropertyValue(object obj, string propertyName)
        {
            var objType = obj.GetType();
            var prop = objType.GetProperty(propertyName);

            return prop.GetValue(obj, null);
        }

        public override int VisitStart([NotNull]CBluntParser.StartContext context)
        {
#if DEBUG
            Console.WriteLine("Beginning semantic checking");
            Console.WriteLine("VisitStart");
#endif

            var declarationIter = 0;
            var functionIter = 0;

            /// TODO: Very hackfixy still. Rule: (function | declaration ';')+
            for (var i = 0; i < context.ChildCount; ++i)
            {
                if (context.declaration(declarationIter) != null)
                {
                    Visit(context.declaration(declarationIter));
                    ++declarationIter;
                    continue;
                }
                    
                    
                if (context.function(functionIter) != null)
                {
                    Visit(context.function(functionIter));
                    ++functionIter;
                }
            }

#if DEBUG
            Console.WriteLine("Finished semantic checking");
#endif

            return 0;
        }

        public override int VisitDeclaration([NotNull]CBluntParser.DeclarationContext context)
        {
#if DEBUG
            Console.WriteLine("VisitDeclaration");
#endif
            // Get the variable's type. We do not need to check if the variable's type is correct because that has already been done by the parser
            var variableType = context.variabletype().GetText();

            // Get the variable's name
            var variableName = context.ID().GetText();

            // Get the variable's value if it exists. A context with 4 children is a declaration followed by an assignment
            var variableValue = context.expression()?.GetText();

            // Get the parent index of this visitor
            var parentRuleIndex = context.Parent.RuleIndex;

            // If the parent's rule is "start", the declared variable needs to be added to the class scope, otherwise we add it to the method's scope
            if (parentRuleIndex == CBluntParser.RULE_start)
            {
                // Check whether the variable exists already in the class scope. Give an error if it exists
                if (FindDeclaredVariableInClassScope(variableName))
                {
                    SyntaxError(context, "Variable with name " + variableName + " already exists");
                    return 0;
                }

                // Add the new variable to the class level and create variable properties for it
                _classScopeVariablesDictionary.Add(variableName, new VariableProperties(variableType, variableValue));
            }
            else
            {
                // Check whether the variable already exists in the method scope
                if (FindDeclaredVariableInMethodScope(variableName))
                {
                    SyntaxError(context, "Variable with name " + variableName + " already exists in current or parent scope");
                    return 0;
                }

                // Add the new variable to the last linked list node, and initialize a dictionary to it
                _methodScopeLinkedList.Last.Value.Add(variableName, new VariableProperties(variableType, variableValue));
            }

            // If no expression is found, simply return as the variable cannot be type-checked against
            if (context.expression() == null)
                return 0;

            // Simplify retrieval of the expression's parameter using a variable. Note that this does not properly handle the grammar's way, as I intentionally omit "calculation*" for testing purposes
            var contextExpressionParameter = context.expression().parameter();

            /// TODO: It may be necessary to determine a better way to do this, potentially utilizing visitor more correctly as this MAY complicate things later
            string foundParameterType = "";

            // Get the name of the expected parameter for potential error output further below
            if (contextExpressionParameter.STRING() != null)
                foundParameterType = "text";

            if (contextExpressionParameter.NUMBER() != null)
                foundParameterType = "number";

            if (contextExpressionParameter.truth() != null)
                foundParameterType = "bool";

            if (contextExpressionParameter.ID() != null)
            {
                // GET VARIABLE, REMEMBER TO CHECK SCOPING (CLASS OR GLOBAL)
                foundParameterType = "id";
            }


            if (contextExpressionParameter.functioncall() != null)
            {
                /// TODO: PUT THIS INTO FUNCTIONCALL, ADD RECURSIVE HANDLING TOO
                /// ADD DIS WHEN RECURS DONE:
                /// SIMPLY: VISIT FUNCTIONCALL TO DETERMINE ERRORS, IF NO ERRORS GRAB DAT TYPE OF THE FUNCTION AND THEN DONE
                // Visit(contextExpressionParameter.functioncall());

                // Helper variables for accessing deeper visitors
                var functionCall = contextExpressionParameter.functioncall();
                var functionCallParameter = functionCall.parameter();

                // The name of the method
                var methodName = contextExpressionParameter.functioncall().ID().GetText();

                // Check if method exists
                if (!SymbolTable.MethodDictionary.ContainsKey(methodName))
                {
                    SyntaxError(context, "Attempting to call method " + methodName + " that does not exist");
                    return 0;
                }

                // Get the method's properties
                var methodProperties = SymbolTable.MethodDictionary[methodName];

                /// TODO: Make this into a simple method
                var methodNiceName = methodName;

                methodNiceName += "(";

                foreach (var paramType in methodProperties.ParameterTypes)
                {
                    methodNiceName += paramType + ",";
                }

                // Remove the last comma
                methodNiceName = methodNiceName.Remove(methodNiceName.Length - 1);

                methodNiceName += ")";
                /// ^ TURN THIS INTO A UTILITY METHOD

                // Check if the method takes parameters. If the functioncall sends a parameter and the method does not take any, stop and give error
                if (functionCall.parameter(0) != null)
                {
                    if (methodProperties.ParameterTypes.Count == 0)
                    {
                        SyntaxError(context, "Method with name " + methodName + " does not take any parameters");
                        return 0;
                    }
                }

                // Compare the method's parameters with the found parameters to see whether they match
                int parameterIter = 0;
                while (functionCall.parameter(parameterIter) != null)
                {
                    var sentParameterType = "";

                    var functionCallParameterType = functionCall.parameter(parameterIter);

                    if (functionCallParameterType.STRING() != null)
                        sentParameterType = "text";

                    if (functionCallParameterType.NUMBER() != null)
                        sentParameterType = "number";

                    if (functionCallParameterType.truth() != null)
                        sentParameterType = "bool";

                    /*
                    // GET THE VARIABLE FROM FIRST THE METHOD SCOPE THEN THE CLASS SCOPE
                    if (awer.ID() != null)
                        sentParameterType = "id";

                    // HANDLE FUNCTIONCALL RECURSIVELY
                    if (awer.functioncall() != null)
                        sentParameterType = "func";
                    */

                    // If nothing matched, we got a problem
                    if (sentParameterType == "")
                    {
                        Console.WriteLine("Houston, we have a problem");
                        return 0;
                    }

                    if (methodProperties.ParameterTypes.Count < parameterIter+1)
                    {
                        SyntaxError(context, "Method " + methodNiceName + " does not take " + (parameterIter+1) + " parameters");
                        return 0;
                    }

                    var expectedMethodParameterType = methodProperties.ParameterTypes[parameterIter];

                    if (expectedMethodParameterType != sentParameterType)
                    {
                        SyntaxError(context, "Method " + methodNiceName + " got type " + sentParameterType + " as parameter number " + (parameterIter+1) + ", expected " + expectedMethodParameterType);
                        return 0;
                    }

                    ++parameterIter;
                }

                if (methodProperties.ParameterTypes.Count > parameterIter)
                {
                    SyntaxError(context, "Method " + methodNiceName + " got " + parameterIter + " parameters, expected " + methodProperties.ParameterTypes.Count);
                    return 0;
                }

                // Set the expected parameter type to the method's properties
                foundParameterType = methodProperties.Type;
            }

            /// TODO: ID requires specialized handling as it first has to be evaluated if the ID even exists, and what the type of ID is.
            // Evaluation of ID is here because we can simply stop if the ID exists and is of the same type. This can only be done when registering of variables is done
            if (foundParameterType == "id")
            {


                return 0;
            }

            // Check the variable's type with the found type
            if (variableType != foundParameterType)
            {
                SyntaxError(context, "Expected " + variableType + ", got " + foundParameterType);
                return 0;
            }

            return 0;
        }

        public override int VisitFunction([NotNull]CBluntParser.FunctionContext context)
        {
#if DEBUG
            Console.WriteLine("VisitFunction");
#endif

            // Create a new scope to the linked list
            _methodScopeLinkedList.AddLast(new Dictionary<string, VariableProperties>());


            // Get the method's type
            var methodType = context.children[0].GetText();

            // Get the method's name
            var methodName = context.children[1].GetText();

            // Create the actual properties for the method
            MethodProperties methodProperties = new MethodProperties
            {
                // Set the type of the method
                Type = methodType,

                // Create the parameter types list for parsing of the method's parameters
                ParameterTypes = new List<string>()
            };

            // Check whether the method contains parameters. If so, add the parameter types to the methodProperties and add the variables
            // to the main scope of the method
            if (context.children.Count > 5)
            {
                var parameterObjects = context.children.Count - 5;

                // Start from 3 as that is the first potential parameter. Addition-operator 2 on i to skip the comma
                for (int i = 3; i < context.children.Count - 2; i += 2)
                {
                    var parameterType = context.children[i].GetText();
                    var parameterName = context.children[++i].GetText();

                    // Add the parameter type to the list of parameter types
                    methodProperties.ParameterTypes.Add(parameterType);

                    // Add the variable along with properties to the method scope
                    _methodScopeLinkedList.Last.Value.Add(parameterName, new VariableProperties(parameterType));
                }
            }


            /// TODO: Check also if method exists already which will have been done if it has been discovered earlier
            /// If so, do not override the dictionary, simply check the methodProperties against the discovered one

            /// TODO: If method has already existed due to discovery nodes, now verify if discovery nodes were true

            // Visit the block of the function
            Visit(context.block());

            // Remove the scope
            _methodScopeLinkedList.RemoveLast();

            return 0;
        }

        public override int VisitBlock([NotNull]CBluntParser.BlockContext context)
        {
#if DEBUG
            Console.WriteLine("VisitBlock");
#endif

             // Iterate over all potential statements in the block. There can be 0 statements here
            for (var i = 0; i < context.ChildCount; ++i)
            {
                if (context.statement(i) != null)
                    Visit(context.statement(i));
            }

            return 0;
        }

        public override int VisitExpression([NotNull]CBluntParser.ExpressionContext context)
        {
#if DEBUG
            Console.WriteLine("VisitExpression");
#endif
            if (context.parameter() != null)
                Visit(context.parameter());

            /*if (context.calculation() != null)
                Visit(context.calculation(0));*/

            return 0;
        }

        public override int VisitParameter([NotNull]CBluntParser.ParameterContext context)
        {
#if DEBUG
            Console.WriteLine("VisitParameter");
#endif

            if (context.ID() != null)
            {
                
            }

            return 0;
        }

        public override int VisitVariableedit([NotNull] CBluntParser.VariableeditContext context)
        {
#if DEBUG
            Console.WriteLine("VisitVariableedit");
#endif
            // The name of the variable
            var variableName = context.children[0].GetText();

            // The operator type (For example: = += /= so on)
            var operatorType = context.children[1].GetText();

            // The assignment value
            var assignmentValue = context.children[2].GetText();

            // First iterate over the current scope and all previous scopes
            var currNode = _methodScopeLinkedList.Last;
            var variableExists = false;

            // The properties of the variable we found
            VariableProperties variableProperties = null;

            // In order to edit a variable, we first need to check the method's scopes. If it was not found here, the class scope is checked
            while (true)
            {
                // Get the value (aka. dictionary) of the scope
                var scopeVariables = currNode.Value;

                // Stop the loop if the variable has been found in the current scope
                if (scopeVariables.ContainsKey(variableName))
                {
                    variableProperties = scopeVariables[variableName];
                    variableExists = true;
                    break;
                }

                // If there exists no previous node, stop the loop
                if (currNode.Previous == null)
                    break;

                currNode = currNode.Previous;
            }

            // If the variable was still not found after checking the method scope, we check the class scope
            if (!variableExists)
            {
                if (_classScopeVariablesDictionary.ContainsKey(variableName))
                {
                    variableProperties = _classScopeVariablesDictionary[variableName];
                    variableExists = true;
                }
            }

            // If the variable still was not found, cause an error
            if (!variableExists)
            {
                SyntaxError(context, "Variable with name " + variableName + " cannot be assigned a value as it does not exist.");
                return 0;
            }

            // Get the expected assignment value, aka the value we expect the variable to be assigned
            var contextExpressionParameter = context.expression().parameter();
            var assignmentType = "";

            if (contextExpressionParameter.STRING() != null)
                assignmentType = "text";

            if (contextExpressionParameter.NUMBER() != null)
                assignmentType = "number";

            if (contextExpressionParameter.truth() != null)
                assignmentType = "bool";

            if (contextExpressionParameter.ID() != null)
            {
                /// TODO: Get the variable's type from current or parent scope, or class scope, and determine whether its type matches.
                /// Do not cause any error here, simply set the expectedAssignmentValue and continue
                
            }

            if (contextExpressionParameter.functioncall() != null)
            {
                /// TODO: functioncall is on the list of tasks to do. It requires correct implementation of method discovery along with understanding its return-type.
                /// This means that it won't really cause the error here, it will cause the (potential) error the moment the function is declared or the function is not found
                /// Therefore, if the function is not declared yet, we can actually simply add a discovery node and return here.
                /// 17-04-2019
            }

            switch (operatorType)
            {
                // Always allow default assignment
                case "=":
                    break;

                case "+=":
                    if (assignmentType != "number")
                    {
                        SyntaxError(context, "Cannot use addition assignment operator on a type " + assignmentType);
                        return 0;
                    }
                    break;

                case "-=":
                    if (assignmentType != "number")
                    {
                        SyntaxError(context, "Cannot use subtraction assignment operator on a type " + assignmentType);
                        return 0;
                    }
                    break;

                case "*=":
                    if (assignmentType != "number")
                    {
                        SyntaxError(context, "Cannot use multiplication assignment operator on a type " + assignmentType);
                        return 0;
                    }
                    break;

                case "/=":
                    if (assignmentType != "number")
                    {
                        SyntaxError(context, "Cannot use division assignment operator on a type " + assignmentType);
                        return 0;
                    }
                    break;
            }

            // Now test if this variable's type is the type it tries to assign
            if (variableProperties.Type != assignmentType)
            {
                SyntaxError(context, "Variable " + variableName + " is of type " + variableProperties.Type + ", cannot assign it a value of type " + assignmentType);
                return 0;
            }

            // Finally, set the new value of the variable. This is set out of sheer principle
            variableProperties.Value = assignmentValue;

            return base.VisitVariableedit(context);
        }

        public override int VisitStatement([NotNull] CBluntParser.StatementContext context)
        {
#if DEBUG
            Console.WriteLine("VisitStatement");
#endif
            /// TODO: Iterate as the rule requires it
            //Visit(context.functioncall());

            return base.VisitStatement(context);
        }

        public override int VisitFunctioncall([NotNull] CBluntParser.FunctioncallContext context)
        {
#if DEBUG
            Console.WriteLine("VisitFunctioncall");
#endif
            
            // The name of the method to call
            var methodName = context.ID().GetText();

            // Storage for the passed parameters to the method
            var methodParameters = new List<string>();

            // Get all parameters with their corresponding types for future 
            int iter = 0;
            while (context.parameter(iter) != null)
            {
                if (context.parameter(iter).functioncall() != null)
                {
                    // Handle functioncall recursively
                    Visit(context.parameter(iter).functioncall());
                    Console.WriteLine(1);
                }
                    

                methodParameters.Add(context.parameter(iter).GetText());
                ++iter;
            }

            if (context.Parent.RuleIndex == CBluntParser.RULE_statement)
            {
                if (!FindMethod(methodName))
                {
                    SyntaxError(context, "Attempt to call method " + methodName + " that does not exist");
                    return 0;
                }
            }

            

            return base.VisitFunctioncall(context);
        }

        /*
         *  Determine whether a method exists.
         */
        bool FindMethod(string methodName)
        {
            return SymbolTable.MethodDictionary.ContainsKey(methodName);
        }

        /*
         * A helper method for checking if a method is declared in class scope
         */
        bool FindDeclaredVariable(string variableName)
        {
            // Check method scope first
            if (FindDeclaredVariableInMethodScope(variableName))
                return true;

            // Then check the class scope
            if (FindDeclaredVariableInClassScope(variableName))
                return true;

            // If not found in both of them, variable could not be found
            return false;
        }


        /*
         * A helper metohod for checking if a method is declared in class scope
         */
        bool FindDeclaredVariableInClassScope(string variableName)
        {
            return _classScopeVariablesDictionary.ContainsKey(variableName);
        }

        /*
         * A method for simplifying finding declared variables in the scope of a method (skipping class scope)
         */
        bool FindDeclaredVariableInMethodScope(string variableName)
        {
            // Get the last node to iterate backwards over the linked list. Note that it is impossible for the linked list to be empty initially
            var currNode = _methodScopeLinkedList.Last;

            // Variable for testing whether the variable was found in current or parent scope
            var variableExists = false;

            // This loop will ALWAYS end, as it is certain there will exist at least 1 node, and a node will always have an end, aka. previous == null. Should there somehow not exist such a node (for debugging maybe), it will give an error
            // We need to iterate over all previous scopes and see if the variable is declared as that is not allowed in C#
            while (true)
            {
                // Get the value (aka. dictionary) of the scope
                var scopeVariables = currNode.Value;

                // Stop the loop if the variable has been found in the current scope
                if (scopeVariables.ContainsKey(variableName))
                {
                    variableExists = true;
                    break;
                }

                // If there exists no previous node, stop the loop
                if (currNode.Previous == null)
                    break;

                currNode = currNode.Previous;
            }

            // If variable was not found, return false
            return variableExists;
        }
    }
}