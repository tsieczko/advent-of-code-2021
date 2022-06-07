using System.IO;
using AdventOfCode2021.Day13;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day13
{
	[TestClass]
	public class TransparentOrigami1Test : TestBase
	{
		protected override string DayFolderName => "Day13";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = TransparentOrigami1.Run(lines);

			Assert.AreEqual(3421, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = TransparentOrigami1.Run(lines);

			Assert.AreEqual(10, result);
		}
	}
}
