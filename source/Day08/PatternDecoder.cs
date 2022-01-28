using System;

namespace AdventOfCode2021.Day08
{
	//  aaaa
	// b    c
	// b    c
	//  dddd
	// e    f
	// e    f
	//  gggg
	[Flags]
	public enum Segments
	{
		None = 0,
		A = 1 << 1,
		B = 1 << 2,
		C = 1 << 3,
		D = 1 << 4,
		E = 1 << 5,
		F = 1 << 6,
		G = 1 << 7,

		Zero = A | B | C | E | F | G,
		One = C | F,
		Two = A | C | D | E | G,
		Three = A | C | D | F | G,
		Four = B | C | D | F,
		Five = A | B | D | F | G,
		Six = A | B | D | E | F | G,
		Seven = A | C | F,
		Eight = A | B | C | D | E | F | G,
		Nine = A | B | C | D | F | G,
	}

	public static class PatternDecoder
	{
		public static int Decode(string patternString)
		{
			var segments = Segments.None;

			foreach (var letter in patternString)
			{
				segments |= letter switch
				{
					'a' => Segments.A,
					'b' => Segments.B,
					'c' => Segments.C,
					'd' => Segments.D,
					'e' => Segments.E,
					'f' => Segments.F,
					'g' => Segments.G,
					_ => Segments.None
				};
			}

			return segments switch
			{
				Segments.Zero => 0,
				Segments.One => 1,
				Segments.Two => 2,
				Segments.Three => 3,
				Segments.Four => 4,
				Segments.Five => 5,
				Segments.Six => 6,
				Segments.Seven => 7,
				Segments.Eight => 8,
				Segments.Nine => 9,
				_ => -1
			};
		}
	}
}
