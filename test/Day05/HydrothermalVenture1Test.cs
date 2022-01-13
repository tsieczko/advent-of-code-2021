using AdventOfCode2021.Day05;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021Tests.Day05
{
	[TestClass]
	public class HydrothermalVenture1Test : TestBase
	{
		protected override string DayFolderName => "Day05";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = HydrothermalVenture1.Run(lines);

			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = HydrothermalVenture1.Run(lines);

			Assert.AreEqual(5, result);
		}
	}
}
