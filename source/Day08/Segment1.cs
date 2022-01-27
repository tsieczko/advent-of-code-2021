using System;

namespace AdventOfCode2021.Day08
{
	public static class Segment1
	{
		public static int Run(string[] lines)
		{
			var result = 0;

			foreach (var line in lines)
			{
				var stringSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
				var delimited = line.Split('|', stringSplitOptions);
				var signalPatternStrings = delimited[0].Split(' ', stringSplitOptions);
				var outputPatternStrings = delimited[1].Split(' ', stringSplitOptions);

				foreach (var outputPatternString in outputPatternStrings)
				{
					result += outputPatternString.Length switch
					{
						2 or 3 or 4 or 7 => 1,
						_ => 0,
					};
				}
			}

			return result;
		}
	}
}
