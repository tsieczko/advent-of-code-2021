using System.Collections.Generic;
using System.IO;
using System.Linq;
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

		[TestMethod]
		public void TestGraph()
		{
			var vertices = new List<int>() { 0, 1, 2 };
			var edges = new List<(int, int)>() { (0, 1), (0, 2) };

			var graph = new Graph<int>(vertices);
			foreach (var edge in edges)
			{
				graph.AddEdge(edge.Item1, edge.Item2);
				graph.AddEdge(edge.Item2, edge.Item1);
			}

			var expected = new[]
			{
				new[] { 0, 1 },
				new[] { 0, 2 }
			};

			var paths = graph.Bfs();

			for (var i = 0; i < expected.Length; i++)
			{
				CollectionAssert.AreEqual(expected[i], paths[i]);
			}
		}
	}
}
