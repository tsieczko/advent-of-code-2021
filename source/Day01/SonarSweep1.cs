using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
	public class SonarSweep1
	{
		public static void Run(string path)
		{
			var foundDepthStrings = File.ReadAllLines(path);
			var foundDepths = foundDepthStrings.Select(x => int.Parse(x));

			int numIncreasedMeasurements = 0;
			int previousDepth = -1;
			foreach (var depth in foundDepths)
			{
				if (previousDepth == -1)
				{
					Console.WriteLine($"{depth} (N/A - no previous measurement)");
					previousDepth = depth;
					continue;
				}

				if (depth > previousDepth)
				{
					Console.WriteLine($"{depth} (increased)");
					numIncreasedMeasurements++;
				}
				else if (depth < previousDepth)
				{
					Console.WriteLine($"{depth} (decreased)");
				}
				else
				{
					Console.WriteLine($"{depth} (no change)");
				}

				previousDepth = depth;
			}

			Console.WriteLine(numIncreasedMeasurements);
		}
	}
}
