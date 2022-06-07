using System.IO;
using AdventOfCode2021.Day13;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day13
{
	[TestClass]
	public class TransparentOrigami2Test : TestBase
	{
		protected override string DayFolderName => "Day13";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = TransparentOrigami2.Run(lines);

			Assert.AreEqual(84870, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = TransparentOrigami2.Run(lines);

			Assert.AreEqual(36, result);
		}
	}
}
