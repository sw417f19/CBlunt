﻿using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CBlunt.ANTLR.AutoGeneratedParser;

namespace CBlunt.ANTLR
{
    internal class CBluntVisitor : CBluntBaseVisitor<int>
    {
        List<string> _variables = new List<string>();

        public override int VisitStart([NotNull]CBluntParser.StartContext context)
        {
#if DEBUG
            Console.WriteLine("VisitStart");
#endif

            Console.WriteLine(context.GetText());

            return 0;
        }
    }
}
