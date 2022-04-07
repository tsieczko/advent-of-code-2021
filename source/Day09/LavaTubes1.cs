using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day09
{
	public static class LavaTubes1
	{
		public static int Run(string[] lines)
		{
			var numRows = lines.Length;
			var rowLen = lines[0].Length;

			var heightMapArray = new int[numRows, rowLen];

			for (var row = 0; row < lines.Length; row++)
			{
				var line = lines[row];

				for (var col = 0; col < line.Length; col++)
				{
					heightMapArray[row, col] = int.Parse(line.Substring(col, 1));
				}
			}

			var lowPoints = FindAllLowPoints(heightMapArray);

			return lowPoints.Sum() + lowPoints.Count;
		}

		public static IList<int> FindAllLowPoints(int[,] heightMapArray)
		{
			var result = new List<int>();

			for (var row = 0; row < heightMapArray.GetLength(0); row++)
			{
				for (var col = 0; col < heightMapArray.GetLength(1); col++)
				{
					var currentPoint = heightMapArray[row, col];

					var neighbors = GetNeighbors(heightMapArray, row, col);

					if (neighbors.All(neighbor => neighbor > currentPoint))
					{
						result.Add(currentPoint);
					}
				}
			}

			return result;
		}

		public static IList<int> GetNeighbors(int[,] heightMapArray, int row, int col)
		{
			var maxRowIndex = heightMapArray.GetLength(0) - 1;
			var maxColIndex = heightMapArray.GetLength(1) - 1;

			var neighbors = new List<int>();

			// up
			if (row > 0)
			{
				neighbors.Add(heightMapArray[row - 1, col]);
			}

			// down
			if (row < maxRowIndex)
			{
				neighbors.Add(heightMapArray[row + 1, col]);
			}

			// left
			if (col > 0)
			{
				neighbors.Add(heightMapArray[row, col - 1]);
			}

			// right
			if (col < maxColIndex)
			{
				neighbors.Add(heightMapArray[row, col + 1]);
			}

			return neighbors;
		}

	}
}
