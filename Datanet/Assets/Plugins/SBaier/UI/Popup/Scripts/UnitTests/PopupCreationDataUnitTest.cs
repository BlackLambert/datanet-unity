using Zenject;
using NUnit.Framework;

namespace SBaier.Popup.Tests
{
	[TestFixture]
	public class PopupCreationDataUnitTest : ZenjectUnitTestFixture
	{
		private const string _popupPrefabPath = "Prefabs/Tests/TestPopup";
		private const string _popupStructurePrefabPath = "Prefabs/Tests/TestStructure";
		private const string _popupContentsPrefabPath = "Prefabs/Tests/TestContent";

		[SetUp]
		public void Install()
		{
			Container.Bind<PopupInstaller>().FromResource(_popupPrefabPath).AsSingle();
			Container.Bind<PopupStructure>().FromResource(_popupStructurePrefabPath).AsSingle();
			Container.Bind<PopupContent>().FromResource(_popupContentsPrefabPath).AsSingle();
			Container.Bind<PopupCreationData>().AsSingle();
			Container.Inject(this);
		}
		
		[Inject]
		private PopupCreationData _popupCreationData = null;
		[Inject]
		private PopupInstaller _popup = null;
		[Inject]
		private PopupStructure _structure = null;
		[Inject]
		private PopupContent _content = null;

		[Test]
		public void CostructorInputEqualsProperties()
		{
			Assert.AreEqual(_popup, _popupCreationData.PopupPrefab);
			Assert.AreEqual(_structure, _popupCreationData.PopupStructure);
			Assert.AreEqual(_content, _popupCreationData.PopupContent);
		}
	}
}