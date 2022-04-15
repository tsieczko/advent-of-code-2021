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

		#region get neighbors

		public bool TryGetLeft(out (int Row, int Col, int Height) result)
		{
			if (Col - 1 >= 0)
			{
				result = (Row, Col - 1, _heightMapArray[Row, Col - 1]);
				return true;
			}

			result = default;
			return false;
		}

		public bool TryGetRight(out (int Row, int Col, int Height) result)
		{
			if (Col + 1 <= MaxColIndex)
			{
				result = (Row, Col + 1, _heightMapArray[Row, Col + 1]);
				return true;
			}

			result = default;
			return false;
		}

		public bool TryGetDown(out (int Row, int Col, int Height) result)
		{
			if (Row + 1 <= MaxRowIndex)
			{
				result = (Row + 1, Col, _heightMapArray[Row + 1, Col]);
				return true;
			}

			result = default;
			return false;
		}

		public bool TryGetUp(out (int Row, int Col, int Height) result)
		{
			if (Row - 1 >= 0)
			{
				result = (Row - 1, Col, _heightMapArray[Row - 1, Col]);
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

		public bool TryMoveLeft()
		{
			if (Col > 0)
			{
				Col -= 1;
				return true;
			}

			return false;
		}

		public bool TryMoveRight()
		{
			if (Col < MaxColIndex)
			{
				Col += 1;
				return true;
			}

			return false;
		}

		public bool TryMoveDown()
		{
			if (Row < MaxRowIndex)
			{
				Row += 1;
				return true;
			}

			return false;
		}

		public bool TryMoveUp()
		{
			if (Row > 0)
			{
				Row -= 1;
				return true;
			}

			return false;
		}

		#endregion

		public bool IsLowPoint()
		{
			if (TryGetLeft(out var left) && CurrentPoint > left.Height)
			{
				return false;
			}
			if (TryGetRight(out var right) && CurrentPoint > right.Height)
			{
				return false;
			}
			if (TryGetDown(out var down) && CurrentPoint > down.Height)
			{
				return false;
			}
			if (TryGetUp(out var up) && CurrentPoint > up.Height)
			{
				return false;
			}

			return true;
		}
	}
}
