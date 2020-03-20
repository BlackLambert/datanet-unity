using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing.UI;
using NUnit.Framework;
using SBaier.Datanet.Core;
using SBaier.Storage;

namespace SBaier.Datanet.Tests
{
	public class NodesCountDisplayTest : UIIntegrationTestFixture
	{
		private const string _netName = "MyNet";

		public void Install()
		{
			PreInstall();

			//Setup scene
			PrepareHightMatchingCanvasStage(Container);

			//Bindings
			Container.Bind<DataNetFactory>().To<DataNetFactoryImpl>().AsSingle();
			Container.Bind<DataNetsRepository>().To<DataNetsRepositoryImpl>().AsSingle();
			Container.Bind<DataNetNameValidator>().To<DataNetNameValidatorImpl>().AsSingle();
			Container.Resolve<DataNetsRepository>().Store(new DataNets());
			DataNet data = Container.Resolve<DataNetFactory>().Create(new DataNetFactory.Parameter(_netName));
			Container.Bind<DataNet>().FromInstance(data).AsSingle();
			Container.Bind<NodeFactory>().To<NodeFactoryImpl>().AsSingle();
			Container.Bind(typeof(NodeCountDisplay)).FromComponentInNewPrefabResource(ResourcePaths.NetDashboard_NodeCountDisplay).AsSingle().NonLazy();

			PostInstall();
			
			_firstNode = _nodeFactory.Create(new NodeFactory.Parameter());
			_secondNode = _nodeFactory.Create(new NodeFactory.Parameter());
			
		}

		[Inject]
		private NodeCountDisplay _nodeCountDisplay = null;
		[Inject]
		private NodeFactory _nodeFactory = null;
		[Inject]
		private DataNet _selectedNet = null;
		private Node _firstNode;
		private Node _secondNode;

		[UnityTest]
		public IEnumerator HasCorrectStateOnEmptyNet()
		{
			Install();
			yield return 0;

			Assert.AreEqual(0.ToString(), _nodeCountDisplay.CounterText.text);
		}

		[UnityTest]
		public IEnumerator HasCorrectStateOnNetWithNodes()
		{
			Install();
			yield return 0;

			_selectedNet.AddNode(_firstNode);
			_selectedNet.AddNode(_secondNode);
			yield return 0;
			Assert.AreEqual(2.ToString(), _nodeCountDisplay.CounterText.text);
		}

		[UnityTest]
		public IEnumerator ChangesDisplayOnNodeAdded()
		{
			Install();
			yield return 0;

			_selectedNet.AddNode(_firstNode);
			yield return 0;
			Assert.AreEqual(1.ToString(), _nodeCountDisplay.CounterText.text);
			_selectedNet.AddNode(_secondNode);
			yield return 0;
			Assert.AreEqual(2.ToString(), _nodeCountDisplay.CounterText.text);
		}

		[UnityTest]
		public IEnumerator ChangesDisplayOnNodeRemoved()
		{
			Install();
			yield return 0;

			_selectedNet.AddNode(_firstNode);
			_selectedNet.AddNode(_secondNode);
			yield return 0;
			Assert.AreEqual(2.ToString(), _nodeCountDisplay.CounterText.text);
			_selectedNet.RemoveNode(_secondNode.ID);
			yield return 0;
			Assert.AreEqual(1.ToString(), _nodeCountDisplay.CounterText.text);
		}
	}
}