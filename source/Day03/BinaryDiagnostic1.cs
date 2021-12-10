using System.Collections.Generic;

namespace AdventOfCode2021.Day03
{
    public static class BinaryDiagnostic1
    {
        public static int Run(string[] binaryNumbers)
        {
            var orderTo1Frequency = new Dictionary<int, int>();

            foreach (var number in binaryNumbers)
            {
                for (int i = 0; i < number.Length; i++)
                {
                    var currentIndex = number.Length - 1 - i;

                    if (!orderTo1Frequency.ContainsKey(currentIndex))
                    {
                        orderTo1Frequency[currentIndex] = 0;
                    }

                    if (number[i] == '1')
                    {
                        orderTo1Frequency[currentIndex] += 1;
                    }
                }
            }

            var gammaRate = GetGammaRate(orderTo1Frequency, binaryNumbers.Length);

            var epsilonRate = gammaRate;
            for (int i = 0; i < binaryNumbers[0].Length; i++)
            {
                epsilonRate ^= 1 << i;
            }

            var powerConsumption = gammaRate * epsilonRate;

            return powerConsumption;
        }

        private static int GetGammaRate(IDictionary<int, int> orderTo1Frequency, int totalRows)
        {
            var result = 0;

            foreach (var (order, frequency) in orderTo1Frequency)
            {
                if (frequency > (totalRows / 2))
                {
                    result |= 1 << order;
                }
            }

            return result;
        }
    }
}
