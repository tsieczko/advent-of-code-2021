using System.IO;
using AdventOfCode2021.Day09;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day09
{
	[TestClass]
	public class LavaTubes1Test : TestBase
	{
		protected override string DayFolderName => "Day09";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = LavaTubes1.Run(lines);

			Assert.AreEqual(462, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = LavaTubes1.Run(lines);

			Assert.AreEqual(15, result);
		}
	}
}
