using AdventOfCode2021.Day04;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021Tests.Day04
{
	[TestClass]
	public class GiantSquid2Test : TestBase
	{
		protected override string DayFolderName => "Day04";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = GiantSquid2.Run(lines);

			Assert.AreEqual(23042, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = GiantSquid2.Run(lines);

			Assert.AreEqual(1924, result);
		}
	}
}
