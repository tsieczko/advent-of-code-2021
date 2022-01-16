﻿namespace AdventOfCode2021.Day05
{
	public struct Point
	{
		public int X;
		public int Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"{X},{Y}";
		}
	}
}
