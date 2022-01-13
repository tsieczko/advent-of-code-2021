namespace AdventOfCode2021.Day01
{
	public class SonarSweep2
	{
		public static int Run(int[] depths)
		{
			var numIncreasedMeasurements = 0;
			for (var i = 2; i < depths.Length - 1; i++)
			{
				if (GetWindow(i, depths) > GetWindow(i - 1, depths))
				{
					numIncreasedMeasurements++;
				}
			}

			return numIncreasedMeasurements;
		}

		private static int GetWindow(int index, int[] arr)
		{
			return arr[index - 1] + arr[index] + arr[index + 1];
		}
	}
}
