using AdventOfCode2021.Day01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace AdventOfCode2021Tests.Day01
{
    [TestClass]
    public class SonarSweep2Test : TestBase
    {
        protected override string DayFolderName => "Day01";

        [TestMethod]
        public override void TestInput()
        {
            // read in test input
            var depths = File.ReadAllLines(TestInputPath).Select(x => int.Parse(x)).ToArray();
            var result = SonarSweep2.Run(depths);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public override void PuzzleInput()
        {
            // read in test input
            var depths = File.ReadAllLines(PuzzleInputPath).Select(x => int.Parse(x)).ToArray();
            var result = SonarSweep2.Run(depths);

            Assert.AreEqual(1618, result);
        }
    }
}
