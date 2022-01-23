using System.Linq;

namespace AdventOfCode2021.Day06
{
	public static class Lanternfish2
	{
		public static long Run(string[] lines)
		{
			var startingLanternfishTimers = lines[0].Split(',').Select(x => int.Parse(x));
			var lanternfishManager = new LanternfishManager(startingLanternfishTimers);

			lanternfishManager.AdvanceDays(days: 256);

			return lanternfishManager.TotalLanternfish;
		}
	}
}
