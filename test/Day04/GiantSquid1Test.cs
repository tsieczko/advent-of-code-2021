using System.IO;
using AdventOfCode2021.Day04;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day04
{
	[TestClass]
	public class GiantSquid1Test : TestBase
	{
		protected override string DayFolderName => "Day04";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = GiantSquid1.Run(lines);

			Assert.AreEqual(31424, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = GiantSquid1.Run(lines);

			Assert.AreEqual(4512, result);
		}
	}
}
