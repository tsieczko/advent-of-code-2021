using System.Text;

namespace AdventOfCode2021.Day05
{
	public class Diagram
	{
		const int _diagramSize = 1000;
		int[,] _diagram;

		public Diagram()
		{
			_diagram = new int[_diagramSize, _diagramSize];
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();

			for (int i = 0; i < _diagramSize; i++)
			{
				for (int j = 0; j < _diagramSize; j++)
				{
					stringBuilder.Append($"{_diagram[i, j]:d4}").Append(' ');
				}
			}

			return stringBuilder.ToString();
		}
	}
}