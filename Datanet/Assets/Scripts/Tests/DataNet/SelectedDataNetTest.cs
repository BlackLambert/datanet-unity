using Zenject;
using NUnit.Framework;
using SBaier.Datanet.Core;
using System;

namespace SBaier.Datanet
{
	[TestFixture]
	public class SelectedDataNetTest : ZenjectUnitTestFixture
	{
		private const string _netName = "My Net";

		[SetUp]
		public void Install()
		{
			Container.Bind<SelectedDataNet>().AsSingle();
			Container.Bind<DataNetFactory>().To<DataNetFactoryDummy>().AsSingle();
			Container.Inject(this);

			_netToSelect = _dataNetFactory.Create(new DataNetFactory.Parameter(_netName));
		}

		[Inject]
		private SelectedDataNet _selectedDataNet;
		[Inject]
		private DataNetFactory _dataNetFactory;
		private DataNet _netToSelect;

		[Test]
		public void Selected_HasCorrectDefaultValues()
		{
			Assert.IsNull(_selectedDataNet.Selected);
		}

		[Test]
		public void Selected_GetAndSetWorks()
		{
			_selectedDataNet.Selected = _netToSelect;
			Assert.AreEqual(_netToSelect, _selectedDataNet.Selected);
		}

		[Test]
		public void Selected_EventCalled()
		{
			bool called = false;
			Action listerner = () =>
			{
				called = true;
			};
			_selectedDataNet.OnSelectedChanged += listerner;
			_selectedDataNet.Selected = _netToSelect;
			Assert.True(called);
			_selectedDataNet.OnSelectedChanged -= listerner;
		}
	}
}