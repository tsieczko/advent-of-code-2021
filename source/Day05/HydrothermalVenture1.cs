namespace AdventOfCode2021.Day05
{
	public static class HydrothermalVenture1
	{
		public static int Run(string[] lines)
		{
			var diagram = new Diagram(size: 1000);

			foreach (var line in lines)
			{
				diagram.AddLine(LineFactory.CreateLine(line));
			}

			var points = diagram.Draw();
			var numTwoLinesOverlap = 0;

			foreach (var point in points)
			{
				if (point > 1)
				{
					numTwoLinesOverlap += 1;
				}
			}

			return numTwoLinesOverlap;
		}
	}
}
