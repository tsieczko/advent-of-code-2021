using AdventOfCode2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class SonarSweep1Test
    {
        public string TestFolder { get; } = @"..\..\..\Day01";

        [TestMethod]
        public void SonarSweep1TestInput()
        {
            // read in test input
            var depths = File.ReadAllLines(Path.Combine(TestFolder, "test_input.txt")).Select(x => int.Parse(x)).ToArray();
            var result = SonarSweep1.Run(depths);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void SonarSweep1PuzzleInput()
        {
            // read in test input
            var depths = File.ReadAllLines(Path.Combine(TestFolder, "puzzle_input.txt")).Select(x => int.Parse(x)).ToArray();
            var result = SonarSweep1.Run(depths);

            Assert.AreEqual(1581, result);
        }
    }
}
