using System.Linq;

namespace AdventOfCode2021.Day11
{
	public static class DumboOctopus2
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

			var numOctopus = rowLength * colLength;
			var stepNumber = 0;

			while (true)
			{
				stepNumber += 1;
				if (numOctopus == DumboOctopus1.DoFlashStep(octopi))
				{
					break;
				}
			}

			return stepNumber;
		}
	}
}
