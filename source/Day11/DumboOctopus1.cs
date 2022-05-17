using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day11
{
	public static class DumboOctopus1
	{
		public static int Run(string[] lines)
		{
			var octopuses = new Octopus[10, 10];

			// load octopuses
			foreach (var row in Enumerable.Range(0, 10))
			{
				foreach (var col in Enumerable.Range(0, 10))
				{
					var energy = int.Parse(lines[row].Substring(col, 1));
					octopuses[row, col] = new Octopus(energy, row, col, octopuses);
				}
			}

			var totalFlashes = 0;

			// increase energy level and add to processing queue
			var octopusQueue = new Queue<Octopus>();

			foreach (var _ in Enumerable.Range(0, 10))
			{
				foreach (var octopus in octopuses)
				{
					octopus.Energy += 1;
					octopus.Flashed = false;
					octopusQueue.Enqueue(octopus);
				}

				while (octopusQueue.Count > 0)
				{
					var octopus = octopusQueue.Dequeue();
					if (octopus.Energy > 9 && !octopus.Flashed)
					{
						octopus.Energy = 0;
						octopus.Flashed = true;
						totalFlashes += 1;
						foreach (var neighbor in octopus.GetNeighbors())
						{
							neighbor.Energy += 1;
							octopusQueue.Enqueue(neighbor);
						}
					}
				}
			}

			return totalFlashes;
		}
	}
}
