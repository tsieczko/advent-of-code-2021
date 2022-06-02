using System.Collections.Generic;

namespace AdventOfCode2021.Day12
{
	public class Graph<T>
	{
		public Graph(IEnumerable<T> vertices)
		{
			foreach (var vertex in vertices)
			{
				AdjacencyList.Add(vertex, new List<T>());
			}
		}

		public Dictionary<T, List<T>> AdjacencyList { get; } = new();

		public void AddEdge(T start, T end)
		{
			AdjacencyList[start].Add(end);
		}
	}
}
