using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day11
{
	public static class DumboOctopus1
	{
		public static int Run(string[] lines)
		{
			var rowLength = lines.Length;
			var colLength = lines[0].Length;

			var octopi = new Octopus[rowLength, colLength];

			// load octopuses
			foreach (var row in Enumerable.Range(0, rowLength))
			{
				foreach (var col in Enumerable.Range(0, colLength))
				{
					var energy = int.Parse(lines[row].Substring(col, 1));
					octopi[row, col] = new Octopus(energy, row, col, octopi);
				}
			}

			var totalFlashes = 0;

			foreach (var _ in Enumerable.Range(0, 100))
			{
				totalFlashes += DoFlashStep(octopi);
			}

			return totalFlashes;
		}

		public static int DoFlashStep(Octopus[,] octopi)
		{
			var octopusQueue = new Queue<Octopus>();
			var numFlashes = 0;

			// increase energy level by one
			foreach (var octopus in octopi)
			{
				octopus.Energy += 1;
				octopus.CanFlash = true;
				octopusQueue.Enqueue(octopus);
			}

			// check and process flashes
			while (octopusQueue.Count > 0)
			{
				var octopus = octopusQueue.Dequeue();
				if (octopus.Energy > 9 && octopus.CanFlash)
				{
					octopus.Energy = 0;
					octopus.CanFlash = false;
					numFlashes += 1;
					foreach (var neighbor in octopus.GetNeighbors())
					{
						neighbor.Energy += 1;
						octopusQueue.Enqueue(neighbor);
					}
				}
			}

			// set energy of flashed octopi to zero
			foreach (var octopus in octopi)
			{
				if (!octopus.CanFlash)
				{
					octopus.Energy = 0;
				}
			}

			return numFlashes;
		}
	}
}
