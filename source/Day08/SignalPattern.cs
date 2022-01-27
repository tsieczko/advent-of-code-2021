namespace AdventOfCode2021.Day08
{
	public class SignalPattern
	{
		private bool a = false;
		private bool b = false;
		private bool c = false;
		private bool d = false;
		private bool e = false;
		private bool f = false;
		private bool g = false;

		public SignalPattern(string patternString)
		{
			foreach (var character in patternString)
			{
				switch (character)
				{
					case 'a':
						a = true;
						break;
					case 'b':
						b = true;
						break;
					case 'c':
						c = true;
						break;
					case 'd':
						d = true;
						break;
					case 'e':
						e = true;
						break;
					case 'f':
						f = true;
						break;
					case 'g':
						g = true;
						break;
				}
			}
		}

		public bool Is0 => a && b && c && !d && e && f && g;
		public bool Is1 => !a && !b && c && !d && !e && f && !g;
		public bool Is2 => a && !b && c && d && e && !f && g;
		public bool Is3 => a && !b && c && d && !e && f && g;
		public bool Is4 => !a && b && c && d && !e && f && !g;
		public bool Is5 => a && b && !c && d && !e && f && g;
		public bool Is6 => a && b && !c && d && e && f && g;
		public bool Is7 => a && !b && c && !d && !e && f && !g;
		public bool Is8 => a && b && c && d && e && f && g;
		public bool Is9 => a && b && c && d && !e && f && g;
	}
}
