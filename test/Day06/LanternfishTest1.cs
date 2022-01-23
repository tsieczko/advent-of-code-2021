using System.IO;
using AdventOfCode2021.Day06;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day06
{
	[TestClass]
	public class LanternfishTest1 : TestBase
	{
		protected override string DayFolderName => "Day06";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = Lanternfish1.Run(lines);

			Assert.AreEqual(349549, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = Lanternfish1.Run(lines);

			Assert.AreEqual(5934, result);
		}
	}
}
