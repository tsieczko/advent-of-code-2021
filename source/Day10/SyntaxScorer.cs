using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day10
{
	public static class SyntaxScorer
	{
		public static Dictionary<char, char> ClosingToOpeningSymbols { get; } = new()
		{
			{ ')', '(' },
			{ '}', '{' },
			{ ']', '[' },
			{ '>', '<' }
		};

		public static Dictionary<char, char> OpeningToClosingSymbols { get; } = new()
		{
			{ '(', ')' },
			{ '{', '}' },
			{ '[', ']' },
			{ '<', '>' }
		};

		public static char FindFirstIllegalCharacter(string line)
		{
			var symbolStack = new Stack<char>();

			foreach (var symbol in line)
			{
				if (ClosingToOpeningSymbols.TryGetValue(symbol, out var openingSymbol))
				{
					if (symbolStack.Pop() != openingSymbol)
					{
						return symbol;
					}
				}
				else
				{
					symbolStack.Push(symbol);
				}
			}

			return default;
		}

		public static string CompleteLine(string line)
		{
			var symbolStack = new Stack<char>();

			foreach (var symbol in line)
			{
				if (ClosingToOpeningSymbols.TryGetValue(symbol, out var openingSymbol))
				{
					if (symbolStack.Pop() != openingSymbol)
					{
						// line is corrupt, return empty string
						return null;
					}
				}
				else
				{
					symbolStack.Push(symbol);
				}
			}

			var result = new StringBuilder();

			while (symbolStack.Count > 0)
			{
				var symbol = symbolStack.Pop();

				if (OpeningToClosingSymbols.TryGetValue(symbol, out var closingSymbol))
				{
					result.Append(closingSymbol);
				}
			}

			return result.ToString();
		}
	}
}
