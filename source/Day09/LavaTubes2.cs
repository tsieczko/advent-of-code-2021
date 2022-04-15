using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day09
{
	public static class LavaTubes2
	{
		public static int Run(string[] lines)
		{
			var numRows = lines.Length;
			var rowLen = lines[0].Length;

			// construct the height map array
			var heightMapArray = new int[numRows, rowLen];
			for (var row = 0; row < lines.Length; row++)
			{
				var line = lines[row];

				for (var col = 0; col < line.Length; col++)
				{
					heightMapArray[row, col] = int.Parse(line.Substring(col, 1));
				}
			}
			var heightMap = new HeightMap(heightMapArray);

			var lowPoints = FindAllLowPoints(heightMap);

			var basins = new List<HashSet<(int Row, int Col, int Height)>>();
			foreach (var lowPoint in lowPoints)
			{
				basins.Add(ExpandBasin(heightMap, lowPoint));
			}

			var sortedBasins = basins.Select(x => x.Count).OrderByDescending(x => x);

			return sortedBasins.Take(3).Aggregate((x, y) => x * y);
		}

		public static IEnumerable<(int Row, int Col)> FindAllLowPoints(HeightMap heightMap)
		{
			var lowPoints = new List<(int Row, int Col)>();

			for (heightMap.Row = 0; heightMap.Row <= heightMap.MaxRowIndex; heightMap.Row++)
			{
				for (heightMap.Col = 0; heightMap.Col <= heightMap.MaxColIndex; heightMap.Col++)
				{
					if (heightMap.IsLowPoint())
					{
						lowPoints.Add(heightMap.Cord);
					}
				}
			}

			return lowPoints;
		}

		public static HashSet<(int Row, int Col, int Height)> ExpandBasin(HeightMap heightMap, (int Row, int Col) startingPoint)
		{
			heightMap.Cord = (startingPoint.Row, startingPoint.Col);

			var pointsInBasin = new HashSet<(int Row, int Col, int Height)>();
			pointsInBasin.Add((heightMap.Row, heightMap.Col, heightMap.CurrentPoint));

			var pointsToVisit = new Queue<(int Row, int Col, int Height)>();
			pointsToVisit.Enqueue((heightMap.Row, heightMap.Col, heightMap.CurrentPoint));

			while (pointsToVisit.Count > 0)
			{
				var (currentRow, currentCol, currentHeight) = pointsToVisit.Dequeue();
				heightMap.Cord = (currentRow, currentCol);

				if (heightMap.TryGetLeft(out var left))
				{
					if (left.Height < 9 && left.Height >= currentHeight)
					{
						if (pointsInBasin.Add(left))
						{
							pointsToVisit.Enqueue(left);
						}
					}
				}
				if (heightMap.TryGetRight(out var right))
				{
					if (right.Height < 9 && right.Height >= currentHeight)
					{
						if (pointsInBasin.Add(right))
						{
							pointsToVisit.Enqueue(right);
						}
					}
				}
				if (heightMap.TryGetUp(out var up))
				{
					if (up.Height < 9 && up.Height >= currentHeight)
					{
						if (pointsInBasin.Add(up))
						{
							pointsToVisit.Enqueue(up);
						}
					}
				}
				if (heightMap.TryGetDown(out var down))
				{
					if (down.Height < 9 && down.Height >= currentHeight)
					{
						if (pointsInBasin.Add(down))
						{
							pointsToVisit.Enqueue(down);
						}
					}
				}
			}

			return pointsInBasin;
		}
	}
}
