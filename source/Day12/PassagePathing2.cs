using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day12
{
	public static class PassagePathing2
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
				graph.AddEdge(edge);
			}

			var pathsToEnd = new List<List<string>>();
			var history = new Stack<string>();

			FindPaths("start", graph, history, pathsToEnd, "end");

			return pathsToEnd.Count;
		}

		public static void FindPaths(string currentVertex, Graph<string> graph, Stack<string> history, List<List<string>> pathsToEnd, string endingVertex)
		{
			history.Push(currentVertex);

			if (currentVertex == endingVertex)
			{
				pathsToEnd.Add(history.Reverse().ToList());
			}
			else
			{

				foreach (var adjacentVertex in graph.AdjacencyList[currentVertex])
				{
					// the vertex is capital, we can visit it any number of times
					if (adjacentVertex.ToUpper() == adjacentVertex)
					{
						FindPaths(adjacentVertex, graph, history, pathsToEnd, endingVertex);
					}
					// we can only visit the start or end once
					else if (adjacentVertex == "start" || adjacentVertex == "end" && history.Any(x => x == adjacentVertex))
					{
						continue;
					}
					// otherwise we can only visit it twice
					else if (history.Count(x => x == adjacentVertex) < 2)
					{
						FindPaths(adjacentVertex, graph, history, pathsToEnd, endingVertex);
					}
				}
			}

			history.Pop();
		}
	}
}
