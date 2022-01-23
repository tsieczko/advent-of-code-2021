namespace AdventOfCode2021.Day06
{
	public class Lanternfish
	{
		public Lanternfish(int timer, long count)
		{
			Timer = timer;
			Count = count;
		}

		public int Timer { get; private set; } = 0;

		public bool DidReset { get; private set; } = false;

		public long Count { get; set; } = 1;

		public void AdvanceDay()
		{
			Timer--;

			if (Timer < 0)
			{
				DidReset = true;
				Timer = 6;
			}
			else
			{
				DidReset = false;
			}
		}
	}
}
