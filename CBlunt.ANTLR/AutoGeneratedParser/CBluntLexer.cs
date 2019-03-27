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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class CBluntLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, NUMBER=6, STRING=7, ID=8, DIGIT=9, 
		WS=10;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "NUMBER", "STRING", "ID", "DIGIT", 
		"WS"
	};


	public CBluntLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public CBluntLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'='", "';'", "'number'", "'string'", "'void'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, "NUMBER", "STRING", "ID", "DIGIT", 
		"WS"
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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static CBluntLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\f', '\\', '\b', '\x1', '\x4', '\x2', '\t', '\x2', '\x4', 
		'\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', 
		'\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', 
		'\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', 
		'\v', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x5', '\a', '\x30', 
		'\n', '\a', '\x3', '\a', '\x6', '\a', '\x33', '\n', '\a', '\r', '\a', 
		'\xE', '\a', '\x34', '\x3', '\a', '\x3', '\a', '\x6', '\a', '\x39', '\n', 
		'\a', '\r', '\a', '\xE', '\a', ':', '\x5', '\a', '=', '\n', '\a', '\x3', 
		'\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\a', '\b', '\x43', '\n', 
		'\b', '\f', '\b', '\xE', '\b', '\x46', '\v', '\b', '\x3', '\b', '\x3', 
		'\b', '\x3', '\t', '\x3', '\t', '\a', '\t', 'L', '\n', '\t', '\f', '\t', 
		'\xE', '\t', 'O', '\v', '\t', '\x3', '\n', '\x6', '\n', 'R', '\n', '\n', 
		'\r', '\n', '\xE', '\n', 'S', '\x3', '\v', '\x6', '\v', 'W', '\n', '\v', 
		'\r', '\v', '\xE', '\v', 'X', '\x3', '\v', '\x3', '\v', '\x2', '\x2', 
		'\f', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', 
		'\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', '\x3', 
		'\x2', '\a', '\x3', '\x2', '\x32', ';', '\x3', '\x2', '$', '$', '\x5', 
		'\x2', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\x6', '\x2', '\x32', 
		';', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\x5', '\x2', '\v', '\f', 
		'\xF', '\xF', '\"', '\"', '\x2', '\x64', '\x2', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', 
		'\x2', '\x2', '\x3', '\x17', '\x3', '\x2', '\x2', '\x2', '\x5', '\x19', 
		'\x3', '\x2', '\x2', '\x2', '\a', '\x1B', '\x3', '\x2', '\x2', '\x2', 
		'\t', '\"', '\x3', '\x2', '\x2', '\x2', '\v', ')', '\x3', '\x2', '\x2', 
		'\x2', '\r', '/', '\x3', '\x2', '\x2', '\x2', '\xF', '>', '\x3', '\x2', 
		'\x2', '\x2', '\x11', 'I', '\x3', '\x2', '\x2', '\x2', '\x13', 'Q', '\x3', 
		'\x2', '\x2', '\x2', '\x15', 'V', '\x3', '\x2', '\x2', '\x2', '\x17', 
		'\x18', '\a', '?', '\x2', '\x2', '\x18', '\x4', '\x3', '\x2', '\x2', '\x2', 
		'\x19', '\x1A', '\a', '=', '\x2', '\x2', '\x1A', '\x6', '\x3', '\x2', 
		'\x2', '\x2', '\x1B', '\x1C', '\a', 'p', '\x2', '\x2', '\x1C', '\x1D', 
		'\a', 'w', '\x2', '\x2', '\x1D', '\x1E', '\a', 'o', '\x2', '\x2', '\x1E', 
		'\x1F', '\a', '\x64', '\x2', '\x2', '\x1F', ' ', '\a', 'g', '\x2', '\x2', 
		' ', '!', '\a', 't', '\x2', '\x2', '!', '\b', '\x3', '\x2', '\x2', '\x2', 
		'\"', '#', '\a', 'u', '\x2', '\x2', '#', '$', '\a', 'v', '\x2', '\x2', 
		'$', '%', '\a', 't', '\x2', '\x2', '%', '&', '\a', 'k', '\x2', '\x2', 
		'&', '\'', '\a', 'p', '\x2', '\x2', '\'', '(', '\a', 'i', '\x2', '\x2', 
		'(', '\n', '\x3', '\x2', '\x2', '\x2', ')', '*', '\a', 'x', '\x2', '\x2', 
		'*', '+', '\a', 'q', '\x2', '\x2', '+', ',', '\a', 'k', '\x2', '\x2', 
		',', '-', '\a', '\x66', '\x2', '\x2', '-', '\f', '\x3', '\x2', '\x2', 
		'\x2', '.', '\x30', '\a', '/', '\x2', '\x2', '/', '.', '\x3', '\x2', '\x2', 
		'\x2', '/', '\x30', '\x3', '\x2', '\x2', '\x2', '\x30', '\x32', '\x3', 
		'\x2', '\x2', '\x2', '\x31', '\x33', '\t', '\x2', '\x2', '\x2', '\x32', 
		'\x31', '\x3', '\x2', '\x2', '\x2', '\x33', '\x34', '\x3', '\x2', '\x2', 
		'\x2', '\x34', '\x32', '\x3', '\x2', '\x2', '\x2', '\x34', '\x35', '\x3', 
		'\x2', '\x2', '\x2', '\x35', '<', '\x3', '\x2', '\x2', '\x2', '\x36', 
		'\x38', '\a', '\x30', '\x2', '\x2', '\x37', '\x39', '\t', '\x2', '\x2', 
		'\x2', '\x38', '\x37', '\x3', '\x2', '\x2', '\x2', '\x39', ':', '\x3', 
		'\x2', '\x2', '\x2', ':', '\x38', '\x3', '\x2', '\x2', '\x2', ':', ';', 
		'\x3', '\x2', '\x2', '\x2', ';', '=', '\x3', '\x2', '\x2', '\x2', '<', 
		'\x36', '\x3', '\x2', '\x2', '\x2', '<', '=', '\x3', '\x2', '\x2', '\x2', 
		'=', '\xE', '\x3', '\x2', '\x2', '\x2', '>', '\x44', '\a', '$', '\x2', 
		'\x2', '?', '@', '\a', '$', '\x2', '\x2', '@', '\x43', '\a', '$', '\x2', 
		'\x2', '\x41', '\x43', '\n', '\x3', '\x2', '\x2', '\x42', '?', '\x3', 
		'\x2', '\x2', '\x2', '\x42', '\x41', '\x3', '\x2', '\x2', '\x2', '\x43', 
		'\x46', '\x3', '\x2', '\x2', '\x2', '\x44', '\x42', '\x3', '\x2', '\x2', 
		'\x2', '\x44', '\x45', '\x3', '\x2', '\x2', '\x2', '\x45', 'G', '\x3', 
		'\x2', '\x2', '\x2', '\x46', '\x44', '\x3', '\x2', '\x2', '\x2', 'G', 
		'H', '\a', '$', '\x2', '\x2', 'H', '\x10', '\x3', '\x2', '\x2', '\x2', 
		'I', 'M', '\t', '\x4', '\x2', '\x2', 'J', 'L', '\t', '\x5', '\x2', '\x2', 
		'K', 'J', '\x3', '\x2', '\x2', '\x2', 'L', 'O', '\x3', '\x2', '\x2', '\x2', 
		'M', 'K', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\x3', '\x2', '\x2', '\x2', 
		'N', '\x12', '\x3', '\x2', '\x2', '\x2', 'O', 'M', '\x3', '\x2', '\x2', 
		'\x2', 'P', 'R', '\t', '\x2', '\x2', '\x2', 'Q', 'P', '\x3', '\x2', '\x2', 
		'\x2', 'R', 'S', '\x3', '\x2', '\x2', '\x2', 'S', 'Q', '\x3', '\x2', '\x2', 
		'\x2', 'S', 'T', '\x3', '\x2', '\x2', '\x2', 'T', '\x14', '\x3', '\x2', 
		'\x2', '\x2', 'U', 'W', '\t', '\x6', '\x2', '\x2', 'V', 'U', '\x3', '\x2', 
		'\x2', '\x2', 'W', 'X', '\x3', '\x2', '\x2', '\x2', 'X', 'V', '\x3', '\x2', 
		'\x2', '\x2', 'X', 'Y', '\x3', '\x2', '\x2', '\x2', 'Y', 'Z', '\x3', '\x2', 
		'\x2', '\x2', 'Z', '[', '\b', '\v', '\x2', '\x2', '[', '\x16', '\x3', 
		'\x2', '\x2', '\x2', '\f', '\x2', '/', '\x34', ':', '<', '\x42', '\x44', 
		'M', 'S', 'X', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace CBlunt.ANTLR.AutoGeneratedParser
