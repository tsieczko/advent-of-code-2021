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
			var startX = Point1.X;
			var endX = Point2.X;
			var startY = Point1.Y;
			var endY = Point2.Y;

			if (startX == endX) // vertical line
			{
				if (startY > endY) return Direction.North;
				if (startY < endY) return Direction.South;
			}
			if (startY == endY) // horizontal line
			{
				if (startX < endX) return Direction.East;
				if (startX > endX) return Direction.West;
			}
			if (startY > endY) // north
			{
				if (startX < endX) return Direction.Northeast;
				if (startX > endX) return Direction.Northwest;
			}
			if (startY < endY) // south
			{
				if (startX < endX) return Direction.Southeast;
				if (startX > endX) return Direction.Southwest;
			}

			return Direction.None;
		}

		public bool IsDiagonal()
		{
			return GetDirection() switch
			{
				Direction.Northeast => true,
				Direction.Northwest => true,
				Direction.Southeast => true,
				Direction.Southwest => true,
				_ => false
			};
		}
	}
}
