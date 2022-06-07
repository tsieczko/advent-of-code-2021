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
					// we can only visit the start or end once
					if (adjacentVertex == "start" || adjacentVertex == "end" && history.Any(x => x == adjacentVertex))
					{
						continue;
					}
					// the vertex is capital, we can visit it any number of times
					else if (adjacentVertex.ToUpper() == adjacentVertex)
					{
						FindPaths(adjacentVertex, graph, history, pathsToEnd, endingVertex);
					}
					// we can vist a single small cave twice. check if we can vist twice.
					else if (history.Where(x => !x.IsUpper()).WordCount().All(x => x.Count < 2))
					{
						FindPaths(adjacentVertex, graph, history, pathsToEnd, endingVertex);
					}
					// otherwise we can only visit it once
					else if (history.Count(x => x == adjacentVertex) < 1)
					{
						FindPaths(adjacentVertex, graph, history, pathsToEnd, endingVertex);
					}
				}
			}

			history.Pop();
		}

		public static bool IsUpper(this string input)
		{
			return input.ToUpper() == input;
		}

		public static IEnumerable<(string Word, int Count)> WordCount(this IEnumerable<string> words)
		{
			return from word in words
				   group word by word into groupedWords
				   select (groupedWords.Key, groupedWords.Count());
		}
	}
}
