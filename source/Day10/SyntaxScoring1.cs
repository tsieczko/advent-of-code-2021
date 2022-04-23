using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day10
{
	public static class SyntaxScoring1
	{
		public static int Run(string[] lines)
		{
			var lookUpTable = new Dictionary<char, int>()
			{
				{ ')', 3 },
				{ ']', 57 },
				{ '}', 1197 },
				{ '>', 25137 }
			};
			var firstIllegalCharacters = new List<char>();

			foreach (var line in lines)
			{
				var illegalChar = FindFirstIllegalCharacter(line);
				if (illegalChar != char.MinValue)
				{
					firstIllegalCharacters.Add(illegalChar);
				}
			}

			return firstIllegalCharacters.Select(x => lookUpTable[x]).Sum();
		}

		public static char FindFirstIllegalCharacter(string line)
		{
			var symbolStack = new Stack<char>();

			foreach (var symbol in line)
			{
				if (symbol == ')')
				{
					if (symbolStack.Pop() != '(')
					{
						return symbol;
					}
				}
				else if (symbol == '}')
				{
					if (symbolStack.Pop() != '{')
					{
						return symbol;
					}
				}
				else if (symbol == ']')
				{
					if (symbolStack.Pop() != '[')
					{
						return symbol;
					}
				}
				else if (symbol == '>')
				{
					if (symbolStack.Pop() != '<')
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
	}
}
