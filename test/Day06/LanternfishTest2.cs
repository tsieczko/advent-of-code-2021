using AdventOfCode2021.Day06;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021Tests.Day06
{
	[TestClass]
	public class LanternfishTest2 : TestBase
	{
		protected override string DayFolderName => "Day06";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = Lanternfish2.Run(lines);

			Assert.AreEqual(1589590444365, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = Lanternfish2.Run(lines);

			Assert.AreEqual(26984457539, result);
		}
	}
}
