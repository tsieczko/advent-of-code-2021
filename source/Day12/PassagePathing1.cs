using System.Collections.Generic;

namespace AdventOfCode2021.Day12
{
	public static class PassagePathing1
	{
		public static int Run(string[] lines)
		{
			var verticesSet = new HashSet<string>();
			var edges = new List<(string, string)>();

			for (var i = 0; i < lines.Length; i++)
			{
				var line = lines[i];
				var splitLine = line.Split("-", System.StringSplitOptions.RemoveEmptyEntries);
				verticesSet.Add(splitLine[0]);
				verticesSet.Add(splitLine[1]);
				edges.Add((splitLine[0], splitLine[1]));
			}

			var graph = new Graph<string>(verticesSet);
			foreach (var edge in edges)
			{
				graph.AddEdge(edge.Item1, edge.Item2);
				graph.AddEdge(edge.Item2, edge.Item1);
			}

			var paths = graph.Bfs();

			return -1;
		}
	}
}
