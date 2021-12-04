using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
	public class SonarSweep2
	{
		public static void Run(string path)
		{
			var foundDepthStrings = File.ReadAllLines(path);
			var foundDepths = foundDepthStrings.Select(x => int.Parse(x)).ToList();

			int previousDepth = -1;
			int numIncreasedMeasurements = 0;
			for (int i = 1; i < foundDepths.Count() - 1; i++)
			{
				var depth = foundDepths[i-1] + foundDepths[i] + foundDepths[i+1];

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
