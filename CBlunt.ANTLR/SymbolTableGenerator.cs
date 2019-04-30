using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CBlunt.ANTLR.AutoGeneratedParser;
using System.Reflection;

namespace CBlunt.ANTLR
{
    class SymbolTableGenerator : CBluntBaseVisitor<int>
    {
        public override int VisitStart([NotNull] CBluntParser.StartContext context)
        {
#if DEBUG
            Console.WriteLine("Beginning symbol table generation");
            Console.WriteLine("VisitStart");
#endif

            int iter = 0;

            while (context.function(iter) != null)
            {
                Visit(context.function(iter));

                ++iter;
            }


#if DEBUG
            Console.WriteLine("Finished symbol table generation");
#endif
            return 0;
        }

        public override int VisitBlock([NotNull] CBluntParser.BlockContext context)
        {
            return base.VisitBlock(context);
        }

        public override int VisitFunction([NotNull] CBluntParser.FunctionContext context)
        {
#if DEBUG
            Console.WriteLine("VisitFunction");
#endif

            // The type of the method
            var methodType = context.functiontype().GetText();

            // The name of the method
            var methodName = context.ID(0).GetText();

            // The list of parameter types the method has
            var methodTypes = new List<string>();

            int iter = 0;
            while (context.variabletype(iter) != null)
            {
                // Get the parameter type
                var methodParameter = context.variabletype(iter).GetText();

                // Add it to the list of parameter types the method has
                methodTypes.Add(methodParameter);

                // Increment iter
                ++iter;
            }

            // Create MethodProperties object
            var methodProperties = new MethodProperties
            {
                Type = methodType,
                ParameterTypes = methodTypes
            };

            // Add the method along with its properties to the symbol table
            SymbolTable.MethodDictionary.Add(methodName, methodProperties);

            return base.VisitFunction(context);
        }
    }

    /*
     * Store for a variable's properties
     */
    class VariableProperties
    {
        // The type of the variable (number, text, bool etc.)
        public string Type { get; set; }

        // The value of the variable (true, false, 0, "test" etc.)
        /// REMOVE
        public string Value { get; set; }

        // Determine whether the variable has been initialized or not (aka null)
        // It is impossible to initialize a variable with null in CBlunt, therefore this only applies to ex:
        // number a;
        public bool Initialized { get; set; }

        // If not specified, the value of the variable is null
        public VariableProperties(string type, string value = null)
        {
            // Set the variable's type
            Type = type;
        }
    }
}