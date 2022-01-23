using System.Linq;

namespace AdventOfCode2021.Day06
{
	public static class Lanternfish1
	{
		public static int Run(string[] lines)
		{
			var startingLanternfishTimers = lines[0].Split(',').Select(x => int.Parse(x));
			var lanternfishManager = new LanternfishManager(startingLanternfishTimers);

			lanternfishManager.AdvanceDays(days: 80);

			return lanternfishManager.TotalLanternfish;
		}
	}
}
