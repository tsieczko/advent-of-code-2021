using System.IO;
using AdventOfCode2021.Day07;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day07
{
	[TestClass]
	public class Crab1Test : TestBase
	{
		protected override string DayFolderName => "Day07";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = Crab1.Run(lines);

			Assert.AreEqual(344605, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = Crab1.Run(lines);

			Assert.AreEqual(37, result);
		}
	}
}
