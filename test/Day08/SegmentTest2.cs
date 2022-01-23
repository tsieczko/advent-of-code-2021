using System.IO;
using AdventOfCode2021.Day08;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day08
{
	[TestClass]
	public class SeqmentTest2 : TestBase
	{
		protected override string DayFolderName => "Day07";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = Segment2.Run(lines);

			Assert.AreEqual(93699985, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = Segment2.Run(lines);

			Assert.AreEqual(168, result);
		}
	}
}
