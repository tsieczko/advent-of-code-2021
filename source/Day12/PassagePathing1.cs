using System.Collections.Generic;
using System.Linq;

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

			var pathsToEnd = new List<List<string>>();
			var history = new Stack<string>();

			FindPaths("start", graph, history, pathsToEnd, "end");

			return pathsToEnd.Count;
		}

		public static void FindPaths(string currentVertex, Graph<string> graph, Stack<string> history, List<List<string>> pathsToEnd, string endingVertex)
		{
			history.Push(currentVertex);

			if (currentVertex.Equals(endingVertex))
			{
				pathsToEnd.Add(history.Reverse().ToList());
			}
			else
			{

				foreach (var adjacentVertex in graph.AdjacencyList[currentVertex])
				{
					if (adjacentVertex is string adjacentVertexString)
					{
						// the vertex is capital, we can visit it any number of times
						if (adjacentVertexString.ToUpper() == adjacentVertexString)
						{
							FindPaths(adjacentVertex, graph, history, pathsToEnd, endingVertex);
						}
						// otherwise we can only visit it once
						else
						{
							if (history.Count(x => x.Equals(adjacentVertex)) < 1)
							{
								FindPaths(adjacentVertex, graph, history, pathsToEnd, endingVertex);
							}
						}
					}
				}
			}

			history.Pop();
		}
	}
}
