using System;

namespace AdventOfCode2021.Day04
{
    public class BingoBoard
    {
        private int _size;
        private BoardElement[,] _board;

        public BingoBoard(int size)
        {
            _size = size;
            _board = new BoardElement[size, size];
        }

        public override string ToString()
        {
            string result = string.Empty;

            for (int row = 0; row < _size; row++)
            {
                for (int column = 0; column < _size; column++)
                {
                    var boardElement = _board[row, column];
                    result += $"{(boardElement.IsVisited ? "*" : " ")}";
                    result += $"{boardElement.Value:d2}";
                    result += $"{(column == _size - 1 ? Environment.NewLine : " ")}";
                }
            }

            return result;
        }

        public void SetBoard(int row, int column, int value)
        {
            _board[row, column] = new BoardElement
            {
                IsVisited = false,
                Value = value,
            };
        }

        public int GetBoard(int row, int column)
        {
            return _board[row, column].Value;
        }

        public void MarkNumber(int drawnNumber)
        {
            foreach (var boardElement in _board)
            {
                if (boardElement.Value == drawnNumber)
                {
                    boardElement.IsVisited = true;
                }
            }
        }

        public bool IsBingo()
        {
            for (int y = 0; y < _size; y++)
            {
                var isRowBingo = true;
                var isColBingo = true;
                
                for (int x = 0; x < _size; x++)
                {
                    if (!_board[y, x].IsVisited)
                    {
                        isRowBingo = false;
                    }
                    if (!_board[x, y].IsVisited)
                    {
                        isColBingo = false;
                    }
                    if (!isRowBingo && !isColBingo)
                    {
                        break;
                    }
                }

                if (isRowBingo || isColBingo)
                {
                    return true;
                }
            }

            // bingo not found
            return false;
        }

        public int GetSumOfUnmarkedNumbers()
        {
            int result = 0;
            
            foreach (var boardElement in _board)
            {
                if (!boardElement.IsVisited)
                {
                    result += boardElement.Value;
                }
            }

            return result;
        }
    }

    class BoardElement
    {
        public bool IsVisited { get; set; }
        public int Value { get; set; }
    }
}
