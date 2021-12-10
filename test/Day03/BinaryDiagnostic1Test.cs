using AdventOfCode2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class BinaryDiagnostic1Test : TestBase
    {
        protected override string DayFolderName => "Day03";

        [TestMethod]
        public override void TestInput()
        {
            // read in test input
            var binaryNumbers = File.ReadAllLines(TestInputPath);
            var result = BinaryDiagnostic1.Run(binaryNumbers);

            Assert.AreEqual(198, result);
        }

        [TestMethod]
        public override void PuzzleInput()
        {
            // read in test input
            var binaryNumbers = File.ReadAllLines(PuzzleInputPath);
            var result = BinaryDiagnostic1.Run(binaryNumbers);

            Assert.AreEqual(2954600, result);
        }
    }
}
