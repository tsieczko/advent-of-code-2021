using AdventOfCode2021.Day05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day05
{
	[TestClass]
	public class DiagramTest
	{
		public Diagram Diagram { get; set; }

		[TestInitialize]
		public void TestInitialize()
		{
			Diagram = new Diagram(size: 5);
		}

		[TestMethod]
		public void TestDiagramHorizontalLine()
		{
			var expected = new int[5, 5]
			{
				{ 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0 },
				{ 1, 1, 1, 1, 1 },
				{ 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0 }
			};

			var actual = Diagram.AddLine(new Line()
			{
				Point1 = new Point(0, 2),
				Point2 = new Point(4, 2)
			}).Draw();

			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestDiagramVerticalLine()
		{
			var expected = new int[5, 5]
			{
				{ 0, 0, 1, 0, 0 },
				{ 0, 0, 1, 0, 0 },
				{ 0, 0, 1, 0, 0 },
				{ 0, 0, 1, 0, 0 },
				{ 0, 0, 1, 0, 0 }
			};

			var actual = Diagram.AddLine(new Line()
			{
				Point1 = new Point(2, 0),
				Point2 = new Point(2, 4)
			}).Draw();

			CollectionAssert.AreEqual(expected, actual);
		}
	}
}
