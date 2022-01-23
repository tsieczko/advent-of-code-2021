using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day06
{
	public class LanternfishManager
	{
		private const int newLanternfishTimer = 8;

		private List<Lanternfish> _lanternfish = new();

		public LanternfishManager(IEnumerable<int> startingLanternfishTimers)
		{
			_lanternfish.AddRange(startingLanternfishTimers.Select(fishTimer => new Lanternfish(fishTimer)));
		}

		public int TotalLanternfish => _lanternfish.Count;

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
			var newLanternfish = new List<Lanternfish>();

			foreach (var lanternFish in _lanternfish)
			{
				lanternFish.AdvanceDay();

				if (lanternFish.DidReset)
				{
					newLanternfish.Add(new Lanternfish(newLanternfishTimer));
				}
			}

			_lanternfish.AddRange(newLanternfish);
		}
	}
}
