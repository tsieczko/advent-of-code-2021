using System.IO;

namespace AdventOfCode2021Tests
{
	public abstract class TestBase
	{
		#region constant fields

		private const string _testDataRoot = @"..\..\..\";
		private const string _testDataFolder = "TestData";
		private const string _testInputFileName = "test_input.txt";
		private const string _puzzleInputFileName = "puzzle_input.txt";

		#endregion constant fields

		#region fields

		private string _testInputPath;
		private string _puzzleInputPath;

		#endregion fields

		#region properties

		protected abstract string DayFolderName { get; }

		protected string TestInputPath
		{
			get => _testInputPath ??= Path.Combine(_testDataRoot, DayFolderName, _testDataFolder, _testInputFileName);
		}

		protected string PuzzleInputPath
		{
			get => _puzzleInputPath ??= Path.Combine(_testDataRoot, DayFolderName, _testDataFolder, _puzzleInputFileName);
		}

		#endregion properties

		#region methods

		public abstract void TestInput();

		public abstract void PuzzleInput();

		#endregion methods
	}
}
