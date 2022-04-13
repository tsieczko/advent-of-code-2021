namespace AdventOfCode2021.Day09
{
	public class HeightMap
	{
		private int[,] _heightMapArray;

		public HeightMap(int[,] heightMapArray)
		{
			_heightMapArray = heightMapArray;
			MaxRowIndex = heightMapArray.GetLength(0) - 1;
			MaxColIndex = heightMapArray.GetLength(1) - 1;
		}

		public int Row { get; set; } = 0;
		
		public int Col { get; set; } = 0;
		
		public int MaxRowIndex { get; }

		public int MaxColIndex { get; }

		public (int Row, int Col) Cord
		{
			get => (Row, Col);
			set
			{
				Row = value.Row;
				Col = value.Col;
			}
		}

		public int CurrentPoint
		{
			get => _heightMapArray[Row, Col];
		}

		public bool IsLowPoint()
		{
			if (TryGetLeft(out var left) && CurrentPoint > left)
			{
				return false;
			}
			if (TryGetRight(out var right) && CurrentPoint > right)
			{
				return false;
			}
			if (TryGetDown(out var down) && CurrentPoint > down)
			{
				return false;
			}
			if (TryGetUp(out var up) && CurrentPoint > up)
			{
				return false;
			}

			return true;
		}

		#region get neighbors

		public bool TryGetLeft(out int result)
		{
			if (Col - 1 >= 0)
			{
				result = _heightMapArray[Row, Col - 1];
				return true;
			}

			result = default;
			return false;
		}

		public bool TryGetRight(out int result)
		{
			if (Col + 1 <= MaxColIndex)
			{
				result = _heightMapArray[Row, Col + 1];
				return true;
			}

			result = default;
			return false;
		}
		public bool TryGetDown(out int result)
		{
			if (Row + 1 <= MaxRowIndex)
			{
				result = _heightMapArray[Row + 1, Col];
				return true;
			}

			result = default;
			return false;
		}

		public bool TryGetUp(out int result)
		{
			if (Row - 1 >= 0)
			{
				result = _heightMapArray[Row - 1, Col];
				return true;
			}

			result = default;
			return false;
		}

		#endregion

		#region movement

		public void MoveReset()
		{
			Row = 0;
			Col = 0;
		}

		public bool MoveLeft()
		{
			if (Col > 0)
			{
				Col -= 1;
				return true;
			}

			return false;
		}

		public bool MoveRight()
		{
			if (Col < MaxColIndex)
			{
				Col += 1;
				return true;
			}

			return false;
		}

		public bool MoveDown()
		{
			if (Row < MaxRowIndex)
			{
				Row += 1;
				return true;
			}

			return false;
		}

		public bool MoveUp()
		{
			if (Row > 0)
			{
				Row -= 1;
				return true;
			}

			return false;
		}

		#endregion
	}
}
