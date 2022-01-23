using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day04
{
	public static class GiantSquid2
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

			var bingoBoardsToRemove = new List<BingoBoard>();

			foreach (var number in drawnNumbers)
			{
				bingoBoardsToRemove.Clear();

				foreach (var bingoBoard in bingoBoards)
				{
					bingoBoard.MarkNumber(number);

					if (bingoBoards.Count == 1 && bingoBoard.IsBingo())
					{
						var sumOfUnmarkedNumbers = bingoBoards.Single().GetSumOfUnmarkedNumbers();
						var finalScore = number * sumOfUnmarkedNumbers;

						return finalScore;
					}
					else if (bingoBoard.IsBingo())
					{
						bingoBoardsToRemove.Add(bingoBoard);
					}
				}

				bingoBoards.RemoveAll(board => bingoBoardsToRemove.Contains(board));
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

			for (var row = 0; row < boardStrings.Length; row++)
			{
				var rowStrings = boardStrings[row].Split(" ", StringSplitOptions.RemoveEmptyEntries);

				for (var column = 0; column < rowStrings.Length; column++)
				{
					var parsedNumber = int.Parse(rowStrings[column]);
					result.SetBoard(row: row, column: column, value: parsedNumber);
				}
			}

			return result;
		}
	}
}
