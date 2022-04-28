using System.Collections.Generic;

namespace AdventOfCode2021.Day10
{
	public static class SyntaxScoring2
	{
		public static Dictionary<char, int> SymbolPointValues { get; set; } = new()
		{
			{ ')', 1 },
			{ ']', 2 },
			{ '}', 3 },
			{ '>', 4 }
		};

		public static long Run(string[] lines)
		{
			var completionStrings = new List<long>();
			foreach (var line in lines)
			{
				var completionString = SyntaxScorer.CompleteLine(line);
				if (completionString == null)
				{
					// line is corrupted, skip it
					continue;
				}
				completionStrings.Add(scoreCompletionString(completionString));
			}
			completionStrings.Sort();

			return completionStrings[completionStrings.Count / 2];
		}

		public static long scoreCompletionString(string completionString)
		{
			long totalScore = 0;
			foreach (var symbol in completionString)
			{
				totalScore *= 5;
				totalScore += SymbolPointValues[symbol];
			}

			return totalScore;
		}
	}
}
