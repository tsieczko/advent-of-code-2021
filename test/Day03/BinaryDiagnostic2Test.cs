﻿using System.IO;
using AdventOfCode2021.Day03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day03
{
	[TestClass]
	public class BinaryDiagnostic2Test : TestBase
	{
		protected override string DayFolderName => "Day03";

		[TestMethod]
		public override void TestInput()
		{
			// read in test input
			var binaryNumbers = File.ReadAllLines(TestInputPath);
			var result = BinaryDiagnostic2.Run(binaryNumbers);

			Assert.AreEqual(230, result);
		}

		[TestMethod]
		public override void PuzzleInput()
		{
			// read in test input
			var binaryNumbers = File.ReadAllLines(PuzzleInputPath);
			var result = BinaryDiagnostic2.Run(binaryNumbers);

			Assert.AreEqual(1662846, result);
		}
	}
}
