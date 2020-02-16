

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SBaier.Datanet
{
	public class SceneUnloaderOnClick : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }
		[SerializeField]
		private string _sceneName = string.Empty;
		public string SceneName { get { return _sceneName; } }

		protected virtual void Start()
		{
			_button.onClick.AddListener(onClick);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(onClick);
		}

		private void onClick()
		{
			SceneManager.UnloadSceneAsync(_sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
		}
	}
}