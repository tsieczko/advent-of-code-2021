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
			Assert.IsTrue(_heightMap.TryMoveRight());
			Assert.IsFalse(_heightMap.TryMoveRight());
			Assert.IsFalse(_heightMap.TryMoveUp());

			Assert.IsTrue(_heightMap.TryMoveDown());
			Assert.IsFalse(_heightMap.TryMoveDown());
			Assert.IsFalse(_heightMap.TryMoveRight());

			Assert.IsTrue(_heightMap.TryMoveLeft());
			Assert.IsFalse(_heightMap.TryMoveLeft());
			Assert.IsFalse(_heightMap.TryMoveDown());

			Assert.IsTrue(_heightMap.TryMoveUp());
			Assert.IsFalse(_heightMap.TryMoveUp());
			Assert.IsFalse(_heightMap.TryMoveLeft());
		}
		
		[TestMethod]
		public void TestMovement()
		{
			Assert.AreEqual((0, 0), _heightMap.Cord);

			Assert.IsTrue(_heightMap.TryMoveRight());
			Assert.AreEqual((0, 1), _heightMap.Cord);
			
			Assert.IsTrue(_heightMap.TryMoveDown());
			Assert.AreEqual((1, 1), _heightMap.Cord);

			Assert.IsTrue(_heightMap.TryMoveLeft());
			Assert.AreEqual((1, 0), _heightMap.Cord);

			Assert.IsTrue(_heightMap.TryMoveUp());
			Assert.AreEqual((0, 0), _heightMap.Cord);
		}
	}
}
