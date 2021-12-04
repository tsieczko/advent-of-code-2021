namespace AdventOfCode2021
{
    public class SonarSweep1
	{
		public static int Run(int[] depths)
		{
			int numIncreasedMeasurements = 0;
			for (var i = 1; i < depths.Length; i++)
			{
				if (depths[i] > depths[i-1])
                {
					numIncreasedMeasurements++;
                }
			}

			return numIncreasedMeasurements;
		}
	}
}
