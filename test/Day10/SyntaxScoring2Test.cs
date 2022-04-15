using System.IO;
using AdventOfCode2021.Day10;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day10
{
	[TestClass]
	public class SyntaxScoring2Test : TestBase
	{
		protected override string DayFolderName => "Day10";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = SyntaxScoring2.Run(lines);

			Assert.AreEqual(1397760, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = SyntaxScoring2.Run(lines);

			Assert.AreEqual(1134, result);
		}
	}
}
