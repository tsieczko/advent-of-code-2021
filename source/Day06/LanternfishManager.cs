using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day06
{
	public class LanternfishManager
	{
		private const int newLanternfishTimer = 8;

		private readonly List<Lanternfish> _lanternfish = new();

		public LanternfishManager(IEnumerable<int> startingLanternfishTimers)
		{
			var groupedLanternfishTimers = startingLanternfishTimers
				.GroupBy(x => x)
				.Select(x => (timer: x.Key, timerCount: x.Count()));

			_lanternfish.AddRange(groupedLanternfishTimers.Select(x => new Lanternfish(x.timer, x.timerCount)));
		}

		public long TotalLanternfish => _lanternfish.Aggregate((long)0, (acc, lanternfish) => acc + lanternfish.Count);

		public void AdvanceDays(int days)
		{
			while (days > 0)
			{
				AdvanceDay();
				days--;
			}
		}

		public void AdvanceDay()
		{
			long newLanternfishCount = 0;

			foreach (var lanternFish in _lanternfish)
			{
				lanternFish.AdvanceDay();

				if (lanternFish.DidReset)
				{
					newLanternfishCount += lanternFish.Count;
				}
			}

			var timer6Lanterfish = _lanternfish.FindAll(lanternfish => lanternfish.Timer == 6);

			if (timer6Lanterfish.Count == 2)
			{
				timer6Lanterfish[0].Count += timer6Lanterfish[1].Count;
				_lanternfish.Remove(timer6Lanterfish[1]);
			}

			if (newLanternfishCount > 0)
			{
				_lanternfish.Add(new Lanternfish(newLanternfishTimer, newLanternfishCount));
			}
		}
	}
}
