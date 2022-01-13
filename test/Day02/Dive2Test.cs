using AdventOfCode2021.Day02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021Tests.Day02
{
	[TestClass]
	public class Dive2Test : TestBase
	{
		protected override string DayFolderName => "Day02";

		[TestMethod]
		public override void TestInput()
		{
			// read in test input
			var depths = File.ReadAllLines(TestInputPath);
			var result = Dive2.Run(depths);

			Assert.AreEqual(900, result);
		}

		[TestMethod]
		public override void PuzzleInput()
		{
			// read in test input
			var depths = File.ReadAllLines(PuzzleInputPath);
			var result = Dive2.Run(depths);

			Assert.AreEqual(1813062561, result);
		}
	}
}
