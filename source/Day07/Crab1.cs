using System;
using System.Linq;

namespace AdventOfCode2021.Day07
{
	public static class Crab1
	{
		public static int Run(string[] lines)
		{
			var horizontalPositions = lines[0].Split(',').Select(x => int.Parse(x));
			var lowestPostion = horizontalPositions.Min();
			var highestPostion = horizontalPositions.Max();
			var minFuel = int.MaxValue;

			foreach (var currentPosition in Enumerable.Range(lowestPostion, highestPostion - lowestPostion))
			{
				var fuelCost = horizontalPositions.Select(x => Math.Abs(x - currentPosition)).Sum();

				minFuel = fuelCost < minFuel ? fuelCost : minFuel;
			}

			return minFuel;
		}
	}
}
