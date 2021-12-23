using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day04
{
    public static class GiantSquid1
    {
        public static int Run(string[] lines)
        {
            int[] drawnNumbers = null;
            var bingoBoards = new List<BingoBoard>();

            for (var i = 0; i < lines.Length; i++)
            {
                // parse drawn numbers
                if (i == 0)
                {
                    drawnNumbers = ParseDrawnNumbers(lines[0]);
                    continue;
                }

                if (lines[i] == string.Empty)
                {
                    continue;
                }

                var boardStrings = lines[i..(i + 5)];
                var bingoBoard = ParseBingoBoard(boardStrings);
                bingoBoards.Add(bingoBoard);
                i += 5;
            }

            foreach (var number in drawnNumbers)
            {
                foreach (var bingoBoard in bingoBoards)
                {
                    bingoBoard.MarkNumber(number);
                    
                    if (bingoBoard.IsBingo())
                    {
                        var sumOfUnmarkedNumbers = bingoBoard.GetSumOfUnmarkedNumbers();
                        var finalScore = number * sumOfUnmarkedNumbers;

                        return finalScore;
                    }
                }
            }

            return 0;
        }

        public static int[] ParseDrawnNumbers(string commaSeparatedNumbersString)
        {
            var numberStrings = commaSeparatedNumbersString.Split(",");
            var parsedNumbers = numberStrings.Select(numberString => int.Parse(numberString));

            return parsedNumbers.ToArray();
        }

        public static BingoBoard ParseBingoBoard(string[] boardStrings)
        {
            var result = new BingoBoard(size: boardStrings.Length);

            for (int row = 0; row < boardStrings.Length; row++)
            {
                var rowStrings = boardStrings[row].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                for (int column = 0; column < rowStrings.Length; column++)
                {
                    var parsedNumber = int.Parse(rowStrings[column]);
                    result.SetBoard(row: row, column: column, value: parsedNumber);
                }
            }

            return result;
        }
    }
}
