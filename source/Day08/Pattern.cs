using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		/*Zero = A | B | C | E | F | G,
		One = C | F,
		Two = A | C | D | E | G,
		Three = A | C | D | F | G,
		Four = B | C | D | F,
		Five = A | B | D | F | G,
		Six = A | B | D | E | F | G,
		Seven = A | C | F,
		Eight = A | B | C | D | E | F | G,
		Nine = A | B | C | D | F | G,*/
	}
	public static class SegmentFrequencey
	{
		public static int A = 8;
		public static int B = 6;
		public static int C = 8;
		public static int D = 7;
		public static int E = 4;
		public static int F = 9;
		public static int G = 7;
	}

	public class Pattern
	{
		public Segments Segments;

		public Pattern(string patternString)
		{
			foreach (var letter in patternString)
			{
				Segments |= letter switch
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
		}
	}
}
