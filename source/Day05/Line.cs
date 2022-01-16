namespace AdventOfCode2021.Day05
{
	public struct Line
	{
		public Point Point1;
		public Point Point2;

		public Line(Point point1, Point point2)
		{
			Point1 = point1;
			Point2 = point2;
		}

		public override string ToString()
		{
			return $"{Point1} -> {Point2}";
		}

		public Direction GetDirection()
		{
			if (Point1.X == Point2.X && Point1.Y > Point2.Y)
			{
				return Direction.North;
			}
			else if (Point1.X == Point2.X && Point1.Y < Point2.Y)
			{
				return Direction.South;
			}
			else if (Point1.X < Point2.X && Point1.Y == Point2.Y)
			{
				return Direction.East;
			}
			else if (Point1.X > Point2.X && Point1.Y == Point2.Y)
			{
				return Direction.West;
			}

			return Direction.None;
		}
	}
}
