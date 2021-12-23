using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04
{
    public static class GiantSquid1
    {
        public static int Run(string[] lines)
        {
            int[] drawnNumbers;

            for (var i = 0; i < lines.Length; i++)
            {
                // handle drawn numbers
                if (i == 0)
                {
                    drawnNumbers = HandleDrawnNumbers(lines[0]);
                }

                if (lines[i] != "\n")
                {
                    var boardLines = lines[i..(i + 4)];
                    i += 5;
                }
            }
            return 0;
        }

        public static int[] HandleDrawnNumbers(string commaSeparatedNumbersString)
        {
            var numberStrings = commaSeparatedNumbersString.Split(",");
            var parsedNumbers = numberStrings.Select(numberString => int.Parse(numberString));

            return parsedNumbers.ToArray(); ;
        }
    }
}
