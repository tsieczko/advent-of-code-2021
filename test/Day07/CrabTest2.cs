using System.IO;
using AdventOfCode2021.Day07;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day07
{
	[TestClass]
	public class Crab2Test : TestBase
	{
		protected override string DayFolderName => "Day07";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = Crab2.Run(lines);

			Assert.AreEqual(93699985, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = Crab2.Run(lines);

			Assert.AreEqual(168, result);
		}

		[DataTestMethod]
		[DataRow(0, 0)]
		[DataRow(1, 1)]
		[DataRow(2, 3)]
		[DataRow(3, 6)]
		[DataRow(4, 10)]
		[DataRow(5, 15)]
		public void TestComputeMovementCost(int input, int expected)
		{
			var actual = Crab2.ComputeMovementCost(input);

			Assert.AreEqual(expected, actual);
		}
	}
}
