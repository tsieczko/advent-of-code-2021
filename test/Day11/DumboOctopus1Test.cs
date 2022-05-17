using System.IO;
using System.Linq;
using AdventOfCode2021.Day11;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day11
{
	[TestClass]
	public class DumboOctopus1Test : TestBase
	{
		protected override string DayFolderName => "Day11";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = DumboOctopus1.Run(lines);

			Assert.AreEqual(167379, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = DumboOctopus1.Run(lines);

			Assert.AreEqual(26397, result);
		}

		[TestMethod]
		public void TestOctopus()
		{
			var octopuses = new Octopus[4,4];

			// load octopuses
			foreach (var row in Enumerable.Range(0, 4))
			{
				foreach (var col in Enumerable.Range(0, 4))
				{
					octopuses[row, col] = new Octopus(0, row, col, octopuses);
				}
			}

			Assert.AreEqual(3, octopuses[0, 0].GetNeighbors().Count());
			Assert.AreEqual(5, octopuses[0, 1].GetNeighbors().Count());
			Assert.AreEqual(5, octopuses[1, 0].GetNeighbors().Count());
			Assert.AreEqual(8, octopuses[1, 1].GetNeighbors().Count());

			Assert.AreEqual(3, octopuses[3, 3].GetNeighbors().Count());
			Assert.AreEqual(5, octopuses[3, 2].GetNeighbors().Count());
			Assert.AreEqual(5, octopuses[2, 3].GetNeighbors().Count());
			Assert.AreEqual(8, octopuses[2, 2].GetNeighbors().Count());
		}
	}
}
