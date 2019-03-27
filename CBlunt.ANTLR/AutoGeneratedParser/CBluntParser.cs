//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from CBlunt.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace CBlunt.ANTLR.AutoGeneratedParser {
#pragma warning disable 3021
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class CBluntParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, NUMBER=9, 
		STRING=10, ID=11, DIGIT=12, WS=13;
	public const int
		RULE_start = 0, RULE_expression = 1, RULE_declaration = 2, RULE_types = 3;
	public static readonly string[] ruleNames = {
		"start", "expression", "declaration", "types"
	};

	private static readonly string[] _LiteralNames = {
		null, "'='", "';'", "'array'", "'{'", "'}'", "'number'", "'string'", "'void'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, "NUMBER", "STRING", 
		"ID", "DIGIT", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "CBlunt.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static CBluntParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public CBluntParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public CBluntParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class StartContext : ParserRuleContext {
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public StartContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_start; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICBluntVisitor<TResult> typedVisitor = visitor as ICBluntVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStart(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StartContext start() {
		StartContext _localctx = new StartContext(Context, State);
		EnterRule(_localctx, 0, RULE_start);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 8; expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public DeclarationContext[] declaration() {
			return GetRuleContexts<DeclarationContext>();
		}
		public DeclarationContext declaration(int i) {
			return GetRuleContext<DeclarationContext>(i);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICBluntVisitor<TResult> typedVisitor = visitor as ICBluntVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpression(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		ExpressionContext _localctx = new ExpressionContext(Context, State);
		EnterRule(_localctx, 2, RULE_expression);
		int _la;
		try {
			State = 18;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 10; declaration();
				State = 14;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__5) | (1L << T__6) | (1L << T__7))) != 0)) {
					{
					{
					State = 11; declaration();
					}
					}
					State = 16;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 17; declaration();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DeclarationContext : ParserRuleContext {
		public TypesContext types() {
			return GetRuleContext<TypesContext>(0);
		}
		public ITerminalNode ID() { return GetToken(CBluntParser.ID, 0); }
		public ITerminalNode NUMBER() { return GetToken(CBluntParser.NUMBER, 0); }
		public ITerminalNode STRING() { return GetToken(CBluntParser.STRING, 0); }
		public DeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_declaration; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICBluntVisitor<TResult> typedVisitor = visitor as ICBluntVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDeclaration(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DeclarationContext declaration() {
		DeclarationContext _localctx = new DeclarationContext(Context, State);
		EnterRule(_localctx, 4, RULE_declaration);
		int _la;
		try {
			State = 43;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 20; types();
				State = 21; Match(ID);
				State = 24;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==T__0) {
					{
					State = 22; Match(T__0);
					State = 23; Match(NUMBER);
					}
				}

				State = 26; Match(T__1);
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 28; types();
				State = 29; Match(ID);
				State = 32;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==T__0) {
					{
					State = 30; Match(T__0);
					State = 31; Match(STRING);
					}
				}

				State = 34; Match(T__1);
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 36; types();
				State = 37; Match(T__2);
				State = 38; Match(ID);
				{
				State = 39; Match(T__0);
				State = 40; Match(T__3);
				State = 41; Match(T__4);
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TypesContext : ParserRuleContext {
		public TypesContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_types; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICBluntVisitor<TResult> typedVisitor = visitor as ICBluntVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTypes(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TypesContext types() {
		TypesContext _localctx = new TypesContext(Context, State);
		EnterRule(_localctx, 6, RULE_types);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 45;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__5) | (1L << T__6) | (1L << T__7))) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\xF', '\x32', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\a', '\x3', '\xF', '\n', 
		'\x3', '\f', '\x3', '\xE', '\x3', '\x12', '\v', '\x3', '\x3', '\x3', '\x5', 
		'\x3', '\x15', '\n', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x5', '\x4', '\x1B', '\n', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x5', 
		'\x4', '#', '\n', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x5', '\x4', '.', '\n', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x2', '\x2', '\x6', '\x2', '\x4', '\x6', '\b', '\x2', '\x3', '\x3', 
		'\x2', '\b', '\n', '\x2', '\x33', '\x2', '\n', '\x3', '\x2', '\x2', '\x2', 
		'\x4', '\x14', '\x3', '\x2', '\x2', '\x2', '\x6', '-', '\x3', '\x2', '\x2', 
		'\x2', '\b', '/', '\x3', '\x2', '\x2', '\x2', '\n', '\v', '\x5', '\x4', 
		'\x3', '\x2', '\v', '\x3', '\x3', '\x2', '\x2', '\x2', '\f', '\x10', '\x5', 
		'\x6', '\x4', '\x2', '\r', '\xF', '\x5', '\x6', '\x4', '\x2', '\xE', '\r', 
		'\x3', '\x2', '\x2', '\x2', '\xF', '\x12', '\x3', '\x2', '\x2', '\x2', 
		'\x10', '\xE', '\x3', '\x2', '\x2', '\x2', '\x10', '\x11', '\x3', '\x2', 
		'\x2', '\x2', '\x11', '\x15', '\x3', '\x2', '\x2', '\x2', '\x12', '\x10', 
		'\x3', '\x2', '\x2', '\x2', '\x13', '\x15', '\x5', '\x6', '\x4', '\x2', 
		'\x14', '\f', '\x3', '\x2', '\x2', '\x2', '\x14', '\x13', '\x3', '\x2', 
		'\x2', '\x2', '\x15', '\x5', '\x3', '\x2', '\x2', '\x2', '\x16', '\x17', 
		'\x5', '\b', '\x5', '\x2', '\x17', '\x1A', '\a', '\r', '\x2', '\x2', '\x18', 
		'\x19', '\a', '\x3', '\x2', '\x2', '\x19', '\x1B', '\a', '\v', '\x2', 
		'\x2', '\x1A', '\x18', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x1B', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1C', 
		'\x1D', '\a', '\x4', '\x2', '\x2', '\x1D', '.', '\x3', '\x2', '\x2', '\x2', 
		'\x1E', '\x1F', '\x5', '\b', '\x5', '\x2', '\x1F', '\"', '\a', '\r', '\x2', 
		'\x2', ' ', '!', '\a', '\x3', '\x2', '\x2', '!', '#', '\a', '\f', '\x2', 
		'\x2', '\"', ' ', '\x3', '\x2', '\x2', '\x2', '\"', '#', '\x3', '\x2', 
		'\x2', '\x2', '#', '$', '\x3', '\x2', '\x2', '\x2', '$', '%', '\a', '\x4', 
		'\x2', '\x2', '%', '.', '\x3', '\x2', '\x2', '\x2', '&', '\'', '\x5', 
		'\b', '\x5', '\x2', '\'', '(', '\a', '\x5', '\x2', '\x2', '(', ')', '\a', 
		'\r', '\x2', '\x2', ')', '*', '\a', '\x3', '\x2', '\x2', '*', '+', '\a', 
		'\x6', '\x2', '\x2', '+', ',', '\a', '\a', '\x2', '\x2', ',', '.', '\x3', 
		'\x2', '\x2', '\x2', '-', '\x16', '\x3', '\x2', '\x2', '\x2', '-', '\x1E', 
		'\x3', '\x2', '\x2', '\x2', '-', '&', '\x3', '\x2', '\x2', '\x2', '.', 
		'\a', '\x3', '\x2', '\x2', '\x2', '/', '\x30', '\t', '\x2', '\x2', '\x2', 
		'\x30', '\t', '\x3', '\x2', '\x2', '\x2', '\a', '\x10', '\x14', '\x1A', 
		'\"', '-',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace CBlunt.ANTLR.AutoGeneratedParser
