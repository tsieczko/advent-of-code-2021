using System.IO;
using AdventOfCode2021.Day08;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day09
{
	[TestClass]
	public class LavaTubes2Test : TestBase
	{
		protected override string DayFolderName => "Day09";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = Segment1.Run(lines);

			Assert.AreEqual(493, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = Segment1.Run(lines);

			Assert.AreEqual(26, result);
		}
	}
}
