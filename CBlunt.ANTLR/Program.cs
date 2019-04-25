﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CBlunt.ANTLR.AutoGeneratedParser;
using System.Threading;

namespace CBlunt.ANTLR
{
    class Program
    {
        private static FileSystemWatcher _watcher;

        private static CBluntParser CreateParser(string input)
        {
            // Create Lexer
            CBluntLexer lexer = new CBluntLexer(new AntlrInputStream(input));

            // Remove default error listener, add our own
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowingErrorListener<int>());

            CBluntParser parser = new CBluntParser(new CommonTokenStream(lexer));

            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ThrowingErrorListener<IToken>());

            return parser;
        }

        private static void GenerateSymbolTable(string input)
        {
            var parser = CreateParser(input);

            // Generate symbol table
            new CBluntSymbolTableGenerator().Visit(parser.start());
        }

        private static void CheckSemantics(string input)
        {
            var parser = CreateParser(input);

            // Check semantics
            new CBluntSemanticChecker().Visit(parser.start());
        }

        private static void GenerateCode(string input)
        {
            var parser = CreateParser(input);

            // Generate code
            new CBluntCodeGenerator().Visit(parser.start());
        }

        private static void DisplayError(Exception ex)
        {
            Console.WriteLine("Parser error:");
            Console.WriteLine(ex.Message);
        }

        public static void Main()
        {
            InitializeFileSystemWatcher();
            LoadFile("SampleCode.txt");

             // Continually loop forever to keep the program (and watcher) alive
            while (true)
            {
                // Reduce CPU usage marginally
                Thread.Sleep(1);
            }
        }

        static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            LoadFile(e.FullPath);
        }

        private static void LoadFile(string filePath)
        {
            // Clear console for clean output
            Console.Clear();

            // Write out timestamp
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));

            // Try-catch is used because an exception can be thrown
            try
            {
                // Read text from the changed file
                string fileText = File.ReadAllText(filePath);

                // Begin compiler
                GenerateSymbolTable(fileText);
                //CheckSemantics(fileText);
                //GenerateCode(fileText);
            }
            catch (Exception exception)
            {
                DisplayError(exception);
            }
        }

        private static void InitializeFileSystemWatcher()
        {
             // Initialize watcher in current directory
            _watcher = new FileSystemWatcher(".");
            
             // Add the method to execute when a file is changed
            _watcher.Changed += new FileSystemEventHandler(Watcher_Changed);
            _watcher.EnableRaisingEvents = true;
            _watcher.IncludeSubdirectories = true;
        }
    }
}
