using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using SBaier.Testing.UI;
using NUnit.Framework;
using SBaier.Datanet.Core;

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

			_selectedNet.NodeContainer.AddNode(_firstNode);
			_selectedNet.NodeContainer.AddNode(_secondNode);
			yield return 0;
			Assert.AreEqual(2.ToString(), _nodeCountDisplay.CounterText.text);
		}

		[UnityTest]
		public IEnumerator ChangesDisplayOnNodeAdded()
		{
			Install();
			yield return 0;

			_selectedNet.NodeContainer.AddNode(_firstNode);
			yield return 0;
			Assert.AreEqual(1.ToString(), _nodeCountDisplay.CounterText.text);
			_selectedNet.NodeContainer.AddNode(_secondNode);
			yield return 0;
			Assert.AreEqual(2.ToString(), _nodeCountDisplay.CounterText.text);
		}

		[UnityTest]
		public IEnumerator ChangesDisplayOnNodeRemoved()
		{
			Install();
			yield return 0;

			_selectedNet.NodeContainer.AddNode(_firstNode);
			_selectedNet.NodeContainer.AddNode(_secondNode);
			yield return 0;
			Assert.AreEqual(2.ToString(), _nodeCountDisplay.CounterText.text);
			_selectedNet.NodeContainer.RemoveNode(_secondNode.ID);
			yield return 0;
			Assert.AreEqual(1.ToString(), _nodeCountDisplay.CounterText.text);
		}
	}
}