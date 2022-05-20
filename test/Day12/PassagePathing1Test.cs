using System.IO;
using AdventOfCode2021.Day12;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day12
{
	[TestClass]
	public class PassagePathing1Test : TestBase
	{
		protected override string DayFolderName => "Day12";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = PassagePathing1.Run(lines);

			Assert.AreEqual(1647, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = PassagePathing1.Run(lines);

			Assert.AreEqual(1656, result);
		}
	}
}
