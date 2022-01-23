using System.IO;
using AdventOfCode2021.Day02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day02
{
	[TestClass]
	public class Dive1Test : TestBase
	{
		protected override string DayFolderName => "Day02";

		[TestMethod]
		public override void TestInput()
		{
			// read in test input
			var depths = File.ReadAllLines(TestInputPath);
			var result = Dive1.Run(depths);

			Assert.AreEqual(150, result);
		}

		[TestMethod]
		public override void PuzzleInput()
		{
			// read in test input
			var depths = File.ReadAllLines(PuzzleInputPath);
			var result = Dive1.Run(depths);

			Assert.AreEqual(1947824, result);
		}
	}
}
