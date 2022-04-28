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
				var illegalChar = SyntaxScorer.FindFirstIllegalCharacter(line);
				if (illegalChar != default)
				{
					firstIllegalCharacters.Add(illegalChar);
				}
			}

			return firstIllegalCharacters.Select(x => lookUpTable[x]).Sum();
		}
	}
}
