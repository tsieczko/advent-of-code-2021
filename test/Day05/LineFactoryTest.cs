using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AdventOfCode2021.Day05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day05
{
	[TestClass]
	public class LineFactoryTest
	{
		private readonly string[] TestStrings = new string[]
		{
			"1,2 -> 3,4",
			"11,22 -> 33,44",
			"111,222 -> 333,444",
			"1111,2222 -> 3333,4444"
		};

		private readonly Line[] ExpectedLines = new Line[]
		{
			new Line(new Point(1,2), new Point(3,4)),
			new Line(new Point(11,22), new Point(33,44)),
			new Line(new Point(111,222), new Point(333,444)),
			new Line(new Point(1111,2222), new Point(3333,4444)),
		};

		private Match[] TestMatches
		{
			get => TestStrings.Select(x => LineFactory.Regex.Match(x)).ToArray();
		}

		private readonly Attribute _attribute = new LineConstructorAttribute();

		[TestMethod]
		public void TestAllLineConstructors()
		{
			var lineParsers = typeof(LineFactory).GetMethods()
				.Where(method => method.GetCustomAttributes().Contains(_attribute));

			foreach (var lineParserMethod in lineParsers)
			{
				foreach ((var match, var expectedLine) in TestMatches.Zip(ExpectedLines))
				{
					var result = lineParserMethod.Invoke(null, new object[] { match });

					Assert.AreEqual(expectedLine, result);
				}
			}
		}
	}
}
