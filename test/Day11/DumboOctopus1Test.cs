using System.IO;
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
	}
}
