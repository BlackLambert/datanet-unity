﻿using System.Threading.Tasks;

namespace SBaier.Persistence.Tests
{
	public class TestDataLoader : DataLoader<TestData>
	{
		public TestData Data { get; private set; }

		public async Task Load()
		{
			await Task.Delay(1);
			Data = new TestData();
		}
	}
}