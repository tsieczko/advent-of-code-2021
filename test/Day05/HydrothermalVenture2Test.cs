using AdventOfCode2021.Day05;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021Tests.Day05
{
	[TestClass]
	public class HydrothermalVenture2Test : TestBase
	{
		protected override string DayFolderName => "Day05";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = HydrothermalVenture2.Run(lines);

			Assert.AreEqual(19939, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = HydrothermalVenture2.Run(lines);

			Assert.AreEqual(12, result);
		}
	}
}
