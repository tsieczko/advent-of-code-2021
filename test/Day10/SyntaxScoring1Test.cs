using System.IO;
using AdventOfCode2021.Day10;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day10
{
	[TestClass]
	public class SyntaxScoring1Test : TestBase
	{
		protected override string DayFolderName => "Day10";

		[TestMethod]
		public override void PuzzleInput()
		{
			var lines = File.ReadAllLines(PuzzleInputPath);
			var result = SyntaxScoring1.Run(lines);

			Assert.AreEqual(167379, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = SyntaxScoring1.Run(lines);

			Assert.AreEqual(26397, result);
		}

		[DataRow("([])", default)]
		[DataRow("(]", ']')]
		[DataRow("{()()()>", '>')]
		[DataRow("(((()))}", '}')]
		[DataRow("<([]){()}[{}])", ')')]
		[DataRow("{([(<{}[<>[]}>{[]{[(<()>", '}')]
		[DataRow("[[<[([]))<([[{}[[()]]]", ')')]
		[DataRow("[{[{({}]{}}([{[{{{}}([]", ']')]
		[DataRow("[<(<(<(<{}))><([]([]()", ')')]
		[DataRow("<{([([[(<>()){}]>(<<{{", '>')]
		[DataTestMethod]
		public void TestFindFirstIllegalCharacter(string input, char expected)
		{
			var result = SyntaxScorer.FindFirstIllegalCharacter(input);
			Assert.AreEqual(expected, result);
		}
	}
}
