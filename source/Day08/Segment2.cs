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
				var signalPatternStrings = delimited[0].Split(' ', stringSplitOptions);
				var outputPatternStrings = delimited[1].Split(' ', stringSplitOptions);

				// compute frequency of segments
				var characterFrequency = ComputeCharacterFrequencey(signalPatternStrings);

				// find the known patterns and map them to their digits
				var digitToSignalPattern = MapKnownDigits(signalPatternStrings);

				// deduce which mixed segments map to correct segments
				var encodedToDecoded = MapEncodedToDecodedSegment(characterFrequency, digitToSignalPattern);

				// decode the output pattern strings using the mapping
				var decodedOutputPatternStrings = DecodePatternStrings(outputPatternStrings, encodedToDecoded);

				var number1 = PatternDecoder.Decode(decodedOutputPatternStrings[0]);
				var number2 = PatternDecoder.Decode(decodedOutputPatternStrings[1]);
				var number3 = PatternDecoder.Decode(decodedOutputPatternStrings[2]);
				var number4 = PatternDecoder.Decode(decodedOutputPatternStrings[3]);

				var decodedEntry = (number1 * 1000) + (number2 * 100) + (number3 * 10) + (number4 * 1);

				result += decodedEntry;
			}

			return result;
		}

		private static string[] DecodePatternStrings(string[] outputPatternStrings, IDictionary<char, char> encodedToDecoded)
		{
			return outputPatternStrings.Select(x => x.DecodeStringWithMapping(encodedToDecoded)).ToArray();
		}

		private static string DecodeStringWithMapping(this string str, IDictionary<char, char> encodedToDecoded)
		{
			return new string(str.Select(chr => encodedToDecoded[chr]).ToArray());
		}

		private static IDictionary<char, char> MapEncodedToDecodedSegment(IDictionary<char, int> characterFrequency, IDictionary<int, string> digitToSignalPattern)
		{
			var decodedToEncoded = new Dictionary<char, char>
			{
				// a is the segments for seven minus the seqments for one
				['a'] = digitToSignalPattern[7].Except(digitToSignalPattern[1]).Single(),
				// b is the segment that occurs 6 times
				['b'] = characterFrequency.Where(x => x.Value == 6).Single().Key,
				// c is the segment that occurs 8 times and is one of the segments for one
				['c'] = characterFrequency.Where(x => x.Value == 8).Where(x => digitToSignalPattern[1].Contains(x.Key)).Single().Key,
				// d is the segment that occurs 7 times and is one of the segments for four
				['d'] = characterFrequency.Where(x => x.Value == 7).Where(x => digitToSignalPattern[4].Contains(x.Key)).Single().Key,
				// e is the segment that occurs 4 times
				['e'] = characterFrequency.Where(x => x.Value == 4).Single().Key,
				// f is the segment that occurs 9 times
				['f'] = characterFrequency.Where(x => x.Value == 9).Single().Key,
				// g is the segment that occurs 7 times and is NOT one of the segments for four
				['g'] = characterFrequency.Where(x => x.Value == 7).Where(x => !digitToSignalPattern[4].Contains(x.Key)).Single().Key
			};

			return decodedToEncoded.ToDictionary(x => x.Value, x => x.Key);
		}

		private static Dictionary<int, string> MapKnownDigits(IEnumerable<string> signalPatternStrings)
		{
			var result = new Dictionary<int, string>();

			foreach (var signalPatternString in signalPatternStrings)
			{
				var knownDigit = signalPatternString.Length switch
				{
					2 => 1,
					3 => 7,
					4 => 4,
					7 => 8,
					_ => -1 // unknown
				};

				if (knownDigit is not -1)
				{
					result.Add(knownDigit, signalPatternString);
				}
			}

			return result;
		}

		private static IDictionary<char, int> ComputeCharacterFrequencey(IEnumerable<string> signalPatternStrings) => signalPatternStrings
			.SelectMany(selector: str => str)
			.GroupBy(keySelector: chr => chr, resultSelector: (chr, group) => (chr, count: group.Count()))
			.ToDictionary(keySelector: tup => tup.chr, elementSelector: tup => tup.count);
	}
}
