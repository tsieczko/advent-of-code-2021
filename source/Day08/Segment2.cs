using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day08
{
	public static class Segment2
	{
		public static int Run(string[] lines)
		{
			var result = 0;

			foreach (var line in lines)
			{
				var stringSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
				var delimited = line.Split('|', stringSplitOptions);
				var signalPatternStrings = delimited[0].Split(' ', stringSplitOptions).Select(str => str.Sort());
				var outputPatternStrings = delimited[1].Split(' ', stringSplitOptions).Select(str => str.Sort());

				var segmentFrequency = signalPatternStrings
					.SelectMany(str => str)
					.GroupBy(chr => chr, (chr, group) => (chr, group.Count()))
					.ToDictionary(tup => tup.Item1, tup => tup.Item2);

				// find the known patterns and map them to their digits
				var signalPatternToDigit = MapKnownDigits(signalPatternStrings);
				var digitToSignalPattern = signalPatternToDigit.Where(x => x.Value != null).ToDictionary(x => x.Value, x => x.Key);
				var outputPatternToDigit = MapKnownDigits(outputPatternStrings);

				var decodedMapping = new Dictionary<char, char>();

				// a is the segments for seven minus the seqments for one
				decodedMapping['a'] = digitToSignalPattern[7].Except(digitToSignalPattern[1]).Single();
				// b is the segment that occurs 6 times
				decodedMapping['b'] = segmentFrequency.Where(x => x.Value == 6).Single().Key;
				// c is the segment that occurs 8 times and is one of the segments for one
				decodedMapping['c'] = segmentFrequency.Where(x => x.Value == 8).Where(x => digitToSignalPattern[1].Contains(x.Key)).Single().Key;
				// d is the segment that occurs 7 times and is one of the segments for four
				decodedMapping['d'] = segmentFrequency.Where(x => x.Value == 7).Where(x => digitToSignalPattern[4].Contains(x.Key)).Single().Key;
				// e is the segment that occurs 4 times
				decodedMapping['e'] = segmentFrequency.Where(x => x.Value == 4).Single().Key;
				// f is the segment that occurs 9 times
				decodedMapping['f'] = segmentFrequency.Where(x => x.Value == 9).Single().Key;
				// g is the segment that occurs 7 times and is NOT one of the segments for four
				decodedMapping['g'] = segmentFrequency.Where(x => x.Value == 7).Where(x => !digitToSignalPattern[4].Contains(x.Key)).Single().Key;
			}

			return result;
		}

		public static string Sort(this string str)
		{
			var charArray = str.ToCharArray();
			Array.Sort(charArray);

			return new string(charArray);
		}

		public static IDictionary<string, int?> MapKnownDigits(IEnumerable<string> patternStrings)
		{
			var result = new Dictionary<string, int?>();

			foreach (var patternString in patternStrings)
			{
				result[patternString] = patternString.Length switch
				{
					2 => 1,
					3 => 7,
					4 => 4,
					7 => 8,
					_ => null
				};
			}

			return result;
		}
	}
}
