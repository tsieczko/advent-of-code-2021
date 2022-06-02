using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day12
{
	public class Graph<T>
	{
		private Dictionary<T, List<T>> _adjacencyList = new();

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
		public List<List<T>> Bfs()
		{
			return Bfs(_adjacencyList.Keys.First());
		}

		public List<List<T>> Bfs(T start)
		{
			var visited = new HashSet<T>();
			var historyStack = new Stack<T>();
			var paths = new List<List<T>>();

			BfsVisit(start, paths, historyStack, visited);

			return paths;
		}

		private void BfsVisit(T start, List<List<T>> paths, Stack<T> historyStack, HashSet<T> visited)
		{
			if (start is string vertexString)
			{
				if (vertexString == vertexString.ToLower())
				{
					visited.Add(start);
				}
			}
			else
			{
				visited.Add(start);
			}

			historyStack.Push(start);

			// if all adjacent are visited, add a path
			if (visited.IsSupersetOf(_adjacencyList[start]))
			{
				paths.Add(historyStack.Reverse().ToList());
			}
			// visit all adjacent
			else
			{
				foreach (var vertex in _adjacencyList[start])
				{
					if (!visited.Contains(vertex))
					{
						BfsVisit(vertex, paths, historyStack, visited);
					}
				}
			}
			historyStack.Pop();
		}

		public List<List<T>> Dfs(T startingVertex, T endingVertex)
		{
			var vertexVistCount = new Dictionary<T, int>();
			foreach (var vertex in _adjacencyList.Keys)
			{
				vertexVistCount[vertex] = 0;
			}
			var pathsToEnd = new List<List<T>>();
			var history = new Stack<T>();

			DfsVisit(startingVertex, vertexVistCount, history, pathsToEnd, endingVertex);

			return pathsToEnd; 
		}

		private void DfsVisit(T currentVertex, Dictionary<T, int> vertexVisitCount, Stack<T> history, List<List<T>> pathsToEnd, T endingVertex)
		{
			history.Push(currentVertex);

			if (currentVertex.Equals(endingVertex))
			{
				pathsToEnd.Add(history.Reverse().ToList());
			}
			else
			{
				//vertexVisitCount[currentVertex]++;

				foreach (var adjacentVertex in _adjacencyList[currentVertex])
				{
					if (adjacentVertex is string adjacentVertexString)
					{
						// the vertex is capital, we can visit it any number of times
						if (adjacentVertexString.ToUpper() == adjacentVertexString)
						{
							//if (vertexVisitCount[adjacentVertex] < 2)
							//if (history.Count(x => x.Equals(adjacentVertex)) < 2)
							{
								DfsVisit(adjacentVertex, vertexVisitCount, history, pathsToEnd, endingVertex);
							}
						}
						// otherwise we can only visit it once
						else
						{
							//if (vertexVisitCount[adjacentVertex] < 1)
							if (history.Count(x => x.Equals(adjacentVertex)) < 1)
							{
								DfsVisit(adjacentVertex, vertexVisitCount, history, pathsToEnd, endingVertex);
							}
						}
					}
				}
			}

			history.Pop();
		}
	}
}
