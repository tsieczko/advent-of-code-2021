using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day12
{
	public class Graph<T>
	{
		private readonly Dictionary<T, List<T>> _adjacencyList = new();

		public Graph(IEnumerable<T> vertices)
		{
			foreach (var vertex in vertices)
			{
				_adjacencyList.Add(vertex, new List<T>());
			}
		}

		public void AddEdge(T start, T end)
		{
			_adjacencyList[start].Add(end);
		}

		public List<List<T>> Dfs(T startingVertex, T endingVertex)
		{
			var pathsToEnd = new List<List<T>>();
			var history = new Stack<T>();

			DfsVisit(startingVertex, history, pathsToEnd, endingVertex);

			return pathsToEnd;
		}

		private void DfsVisit(T currentVertex, Stack<T> history, List<List<T>> pathsToEnd, T endingVertex)
		{
			history.Push(currentVertex);

			if (currentVertex.Equals(endingVertex))
			{
				pathsToEnd.Add(history.Reverse().ToList());
			}
			else
			{

				foreach (var adjacentVertex in _adjacencyList[currentVertex])
				{
					if (adjacentVertex is string adjacentVertexString)
					{
						// the vertex is capital, we can visit it any number of times
						if (adjacentVertexString.ToUpper() == adjacentVertexString)
						{
							DfsVisit(adjacentVertex, history, pathsToEnd, endingVertex);
						}
						// otherwise we can only visit it once
						else
						{
							if (history.Count(x => x.Equals(adjacentVertex)) < 1)
							{
								DfsVisit(adjacentVertex, history, pathsToEnd, endingVertex);
							}
						}
					}
				}
			}

			history.Pop();
		}
	}
}
