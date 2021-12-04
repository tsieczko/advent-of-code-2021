using AdventOfCode2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Dive2Test
    {
        public string TestFolder { get; } = @"..\..\..\Day02";

        [TestMethod]
        public void Dive2TestInput()
        {
            // read in test input
            var depths = File.ReadAllLines(Path.Combine(TestFolder, "test_input.txt"));
            var result = Dive2.Run(depths);

            Assert.AreEqual(900, result);
        }

        [TestMethod]
        public void Dive2PuzzleInput()
        {
            // read in test input
            var depths = File.ReadAllLines(Path.Combine(TestFolder, "puzzle_input.txt"));
            var result = Dive2.Run(depths);

            Assert.AreEqual(1813062561, result);
        }
    }
}
