using AdventOfCode2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Dive1Test
    {
        public string TestFolder { get; } = @"..\..\..\Day02";

        [TestMethod]
        public void Dive1TestInput()
        {
            // read in test input
            var depths = File.ReadAllLines(Path.Combine(TestFolder, "test_input.txt"));
            var result = Dive1.Run(depths);

            Assert.AreEqual(150, result);
        }

        [TestMethod]
        public void Dive1PuzzleInput()
        {
            // read in test input
            var depths = File.ReadAllLines(Path.Combine(TestFolder, "puzzle_input.txt"));
            var result = Dive1.Run(depths);

            Assert.AreEqual(1947824, result);
        }
    }
}
