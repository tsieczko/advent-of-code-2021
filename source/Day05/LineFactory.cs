using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Day05
{
	public static class LineFactory
	{
		public static Regex Regex = new(@"(\d+),(\d+) -> (\d+),(\d+)");

		public static Line CreateLine(string line)
		{
			var match = Regex.Match(line);

			return ConstructLineFromMatch1(match);
		}

		[LineConstructor]
		public static Line ConstructLineFromMatch1(Match match)
		{
			var x1 = int.Parse(match.Groups[1].Value);
			var y1 = int.Parse(match.Groups[2].Value);
			var x2 = int.Parse(match.Groups[3].Value);
			var y2 = int.Parse(match.Groups[4].Value);

			var point1 = new Point()
			{
				X = x1,
				Y = y1
			};
			var point2 = new Point()
			{
				X = x2,
				Y = y2
			};

			var line = new Line()
			{
				Point1 = point1,
				Point2 = point2
			};

			return line;
		}

		[LineConstructor]
		public static Line ConstructLineFromMatch2(Match match) => new Line()
		{
			Point1 = new Point()
			{
				X = int.Parse(match.Groups[1].Value),
				Y = int.Parse(match.Groups[2].Value)
			},
			Point2 = new Point()
			{
				X = int.Parse(match.Groups[3].Value),
				Y = int.Parse(match.Groups[4].Value)
			}
		};

		[LineConstructor]
		public static Line ConstructLineFromMatch3(Match match)
		{
			var x1 = int.Parse(match.Groups[1].Value);
			var y1 = int.Parse(match.Groups[2].Value);
			var x2 = int.Parse(match.Groups[3].Value);
			var y2 = int.Parse(match.Groups[4].Value);

			var point1 = new Point(x1, y1);
			var point2 = new Point(x2, y2);

			var line = new Line(point1, point2);

			return line;
		}

		[LineConstructor]
		public static Line ConstructLineFromMatch4(Match match)
		{
			var x1 = int.Parse(match.Groups[1].Value);
			var y1 = int.Parse(match.Groups[2].Value);
			var x2 = int.Parse(match.Groups[3].Value);
			var y2 = int.Parse(match.Groups[4].Value);

			return new Line(new Point(x1, y1), new Point(x2, y2));
		}

		[LineConstructor]
		public static Line ConstructLineFromMatch5(Match match)
		{
			return new Line(
				new Point(
					int.Parse(match.Groups[1].Value),
					int.Parse(match.Groups[2].Value)),
				new Point(
					int.Parse(match.Groups[3].Value),
					int.Parse(match.Groups[4].Value)));
		}
	}

	[AttributeUsage(AttributeTargets.Method)]
	public class LineConstructorAttribute : Attribute
	{

	}
}
