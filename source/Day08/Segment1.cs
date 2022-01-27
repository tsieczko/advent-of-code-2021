using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day08
{
	public static class Segment1
	{
		public static int Run(string[] lines)
		{
			foreach (var line in lines)
			{
				var stringSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
				var delimited = line.Split('|', stringSplitOptions);
				var signalPatternStrings = delimited[0].Split(' ', stringSplitOptions);
				var outputPatternStrings = delimited[1].Split(' ', stringSplitOptions);

				var signalPatterns = signalPatternStrings.Select(patternString => new SignalPattern(patternString));
				var outputPatterns = outputPatternStrings.Select(patternString => new SignalPattern(patternString));

				var segmentToCount = new Dictionary<char, int>()
				{
					{ 'a', 8 },
					{ 'b', 6 },
					{ 'c', 8 },
					{ 'd', 7 },
					{ 'e', 4 },
					{ 'f', 9 },
					{ 'g', 7 }
				};

				signalPatternStrings.GroupBy(x => x);
			}

			return -1;
		}
	}
}
