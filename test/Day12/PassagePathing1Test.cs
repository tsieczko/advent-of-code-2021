using System.Collections.Generic;
using System.IO;
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

			Assert.AreEqual(3421, result);
		}

		[TestMethod]
		public override void TestInput()
		{
			var lines = File.ReadAllLines(TestInputPath);
			var result = PassagePathing1.Run(lines);

			Assert.AreEqual(10, result);
		}

		[TestMethod]
		public void TestGraphBfs()
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

		[TestMethod]
		public void TestGraphDfs()
		{
			var vertices = new List<string>() { "start", "A", "b", "end" };
			var edges = new List<(string, string)>() { ("start", "A"), ("A", "b"), ("b", "end") };

			var graph = new Graph<string>(vertices);

			foreach (var edge in edges)
			{
				graph.AddEdge(edge.Item1, edge.Item2);
				graph.AddEdge(edge.Item2, edge.Item1);
			}

			var paths = graph.Dfs("start", "end");

			Assert.AreEqual(1, paths.Count);
			CollectionAssert.AreEqual(new[] { "start", "A", "b", "end" }, paths[0]);

			edges = new List<(string, string)>() { ("start", "A"), ("start", "b"), ("A", "end"), ("b", "end") };

			graph = new Graph<string>(vertices);

			foreach (var edge in edges)
			{
				graph.AddEdge(edge.Item1, edge.Item2);
				graph.AddEdge(edge.Item2, edge.Item1);
			}

			paths = graph.Dfs("start", "end");

			Assert.AreEqual(2, paths.Count);
			CollectionAssert.AreEqual(new[] { "start", "A", "end" }, paths[0]);
			CollectionAssert.AreEqual(new[] { "start", "b", "end" }, paths[1]);

			edges = new List<(string, string)>() { ("start", "A"), ("start", "b"), ("A", "b"), ("A", "end"), ("b", "end") };

			graph = new Graph<string>(vertices);

			foreach (var edge in edges)
			{
				graph.AddEdge(edge.Item1, edge.Item2);
				graph.AddEdge(edge.Item2, edge.Item1);
			}

			paths = graph.Dfs("start", "end");

			Assert.AreEqual(5, paths.Count);
			CollectionAssert.AreEqual(new[] { "start", "A", "b", "A", "end" }, paths[0]);
			CollectionAssert.AreEqual(new[] { "start", "A", "b", "end" }, paths[1]);
			CollectionAssert.AreEqual(new[] { "start", "A", "end" }, paths[2]);
			CollectionAssert.AreEqual(new[] { "start", "b", "A", "end" }, paths[3]);
			CollectionAssert.AreEqual(new[] { "start", "b", "end" }, paths[4]);
		}
	}
}
