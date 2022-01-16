using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day05
{
	public class Diagram
	{
		private readonly int _diagramSize;
		private readonly int[,] _diagram;
		private readonly List<Line> _lines = new();

		public Diagram(int size)
		{
			_diagramSize = size;
			_diagram = new int[_diagramSize, _diagramSize];
		}

		public Diagram AddLine(Line line)
		{
			if (line.Point1.X == line.Point2.X || line.Point1.Y == line.Point2.Y)
			{
				_lines.Add(line);
			}

			return this;
		}

		public int[,] Draw()
		{
			foreach (var line in _lines)
			{
				MarkLine(line);
			}

			return _diagram;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();

			for (int y = 0; y < _diagramSize; y++)
			{
				for (int x = 0; x < _diagramSize; x++)
				{
					stringBuilder.Append($"{_diagram[y, x],4}").Append(' ');
				}
				stringBuilder.AppendLine();
			}

			return stringBuilder.ToString();
		}

		private void MarkLine(Line line)
		{
			var current = line.Point1;
			var end = line.Point2;

			while (true)
			{
				MarkPoint(current);

				if (current.Equals(end))
				{
					break;
				}

				current = MovePoint(current, line.GetDirection());
			} 
		}

		private void MarkPoint(Point point)
		{
			_diagram[point.Y, point.X] += 1;
		}

		private static Point MovePoint(Point point, Direction direction)
		{
			switch (direction)
			{
				case Direction.North:
					point.Y -= 1;
					break;
				case Direction.South:
					point.Y += 1;
					break;
				case Direction.East:
					point.X += 1;
					break;
				case Direction.West:
					point.X -= 1;
					break;
			}

			return point;
		}
	}
}