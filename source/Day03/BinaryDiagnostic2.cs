using System.Collections.Generic;

namespace AdventOfCode2021.Day03
{
	public static class BinaryDiagnostic2
	{
		public static int Run(string[] binaryNumbers)
		{
			var O2Rating = GetRating(binaryNumbers, isOxygen: true).ToInt();
			var CO2Rating = GetRating(binaryNumbers, isOxygen: false).ToInt();

			return O2Rating * CO2Rating;
		}

		private static string GetRating(IList<string> binaryNumbers, bool isOxygen, int bitPosition = 0)
		{
			if (binaryNumbers.Count == 1)
			{
				return binaryNumbers[0];
			}

			var firstBit0 = new List<string>();
			var firstBit1 = new List<string>();

			foreach (var number in binaryNumbers)
			{
				if (number.IsBit0(bitPosition))
				{
					firstBit0.Add(number);
				}
				else
				{
					firstBit1.Add(number);
				}
			}

			if (isOxygen)
			{
				if (firstBit1.Count >= firstBit0.Count)
				{
					return GetRating(firstBit1, isOxygen, bitPosition + 1);
				}
				else
				{
					return GetRating(firstBit0, isOxygen, bitPosition + 1);
				}
			}
			else // isCO2
			{
				if (firstBit0.Count <= firstBit1.Count)
				{
					return GetRating(firstBit0, isOxygen, bitPosition + 1);
				}
				else
				{
					return GetRating(firstBit1, isOxygen, bitPosition + 1);
				}
			}
		}

		private static bool IsBit0(this string bitString, int bitPosition)
		{
			return bitString[bitPosition] == '0';
		}

		private static int ToInt(this string bitString)
		{
			int result = 0;

			for (int i = 0; i < bitString.Length; i++)
			{
				var currentBit = bitString[i] == '1' ? 1 : 0;
				var currentIndex = bitString.Length - 1 - i;
				result |= currentBit << currentIndex;
			}

			return result;
		}
	}
}
