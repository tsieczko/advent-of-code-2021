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

			Assert.AreEqual(2776842859, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = SyntaxScoring2.Run(lines);

			Assert.AreEqual(288957, result);
		}

		[DataRow("(", ")")]
		[DataRow("((", "))")]
		[DataRow("([", "])")]
		[DataRow("([]", ")")]
		[DataRow("([]{<", ">})")]
		[DataRow("[({(<(())[]>[[{[]{<()<>>", "}}]])})]")]
		[DataRow("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
		[DataRow("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))")]
		[DataRow("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
		[DataRow("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
		[DataTestMethod]
		public void TestCompleteLine(string input, string output)
		{
			var result = SyntaxScorer.CompleteLine(input);
			Assert.AreEqual(result, output);
		}
	}
}
