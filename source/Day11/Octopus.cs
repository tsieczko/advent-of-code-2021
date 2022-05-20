using System.Collections.Generic;

namespace AdventOfCode2021.Day11
{
	public class Octopus
	{
		private (int row, int column) _location;

		private Octopus[,] _map;

		public Octopus(int energy, int row, int column, Octopus[,] map)
		{
			Energy = energy;
			CanFlash = false;
			_location = (row, column);
			_map = map;
		}

		public int Energy { get; set; }

		public bool CanFlash { get; set; }

		public IEnumerable<Octopus> GetNeighbors()
		{
			for (int row = _location.row - 1; row <= _location.row + 1; row++)
			{
				if (row < 0 || row >= _map.GetLength(0))
				{
					continue;
				}

				for (int col = _location.column - 1; col <= _location.column + 1; col++)
				{
					if (col < 0 || col >= _map.GetLength(1))
					{
						continue;
					}

					if (_location.row == row && _location.column == col)
					{
						continue;
					}

					yield return _map[row, col];
				}
			}
		}

		public override string ToString()
		{
			return $"Octopus: {Energy}";
		}
	}
}
