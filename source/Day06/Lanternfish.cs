namespace AdventOfCode2021.Day06
{
	public class Lanternfish
	{
		private int _timer;

		public Lanternfish(int timer)
		{
			_timer = timer;
		}

		public int Timer => _timer;

		public bool DidReset { get; set; } = false;

		public void AdvanceDay()
		{
			_timer--;

			if (_timer < 0)
			{
				DidReset = true;
				_timer = 6;
			}
			else
			{
				DidReset = false;
			}
		}
	}
}
