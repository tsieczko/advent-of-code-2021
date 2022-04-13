using AdventOfCode2021.Day09;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021Tests.Day09
{
	[TestClass]
	public class HeightMapTest
	{
		private int[,] _heightMapArray;
		
		private HeightMap _heightMap;

		[TestInitialize]
		public void TestInitialize()
		{
			_heightMapArray = new int[2, 2];

			var i = 0;
			for (var row = 0; row < _heightMapArray.GetLength(0); row++)
			{
				for (var col = 0; col < _heightMapArray.GetLength(1); col++)
				{
					_heightMapArray[row, col] = i++;
				}
			}

			_heightMap = new HeightMap(_heightMapArray);
		}

		[TestMethod]
		public void TestMovementBounds()
		{
			Assert.IsTrue(_heightMap.MoveRight());
			Assert.IsFalse(_heightMap.MoveRight());
			Assert.IsFalse(_heightMap.MoveUp());

			Assert.IsTrue(_heightMap.MoveDown());
			Assert.IsFalse(_heightMap.MoveDown());
			Assert.IsFalse(_heightMap.MoveRight());

			Assert.IsTrue(_heightMap.MoveLeft());
			Assert.IsFalse(_heightMap.MoveLeft());
			Assert.IsFalse(_heightMap.MoveDown());

			Assert.IsTrue(_heightMap.MoveUp());
			Assert.IsFalse(_heightMap.MoveUp());
			Assert.IsFalse(_heightMap.MoveLeft());
		}
		
		[TestMethod]
		public void TestMovement()
		{
			Assert.AreEqual((0, 0), _heightMap.Cord);

			Assert.IsTrue(_heightMap.MoveRight());
			Assert.AreEqual((0, 1), _heightMap.Cord);
			
			Assert.IsTrue(_heightMap.MoveDown());
			Assert.AreEqual((1, 1), _heightMap.Cord);

			Assert.IsTrue(_heightMap.MoveLeft());
			Assert.AreEqual((1, 0), _heightMap.Cord);

			Assert.IsTrue(_heightMap.MoveUp());
			Assert.AreEqual((0, 0), _heightMap.Cord);
		}
	}
}
