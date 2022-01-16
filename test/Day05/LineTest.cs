using AdventOfCode2021.Day05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day05
{
	[TestClass]
	public class LineTest
	{
		[TestMethod]
		public void TestNorthLine()
		{
			var line = new Line(new Point(0, 1), new Point(0, 0));

			Assert.AreEqual(Direction.North, line.GetDirection());
		}

		[TestMethod]
		public void TestSouthLine()
		{
			var line = new Line(new Point(0, 0), new Point(0, 1));

			Assert.AreEqual(Direction.South, line.GetDirection());
		}

		[TestMethod]
		public void TestEastLine()
		{
			var line = new Line(new Point(0, 0), new Point(1, 0));

			Assert.AreEqual(Direction.East, line.GetDirection());
		}

		[TestMethod]
		public void TestWestLine()
		{
			var line = new Line(new Point(1, 0), new Point(0, 0));

			Assert.AreEqual(Direction.West, line.GetDirection());
		}
	}
}
