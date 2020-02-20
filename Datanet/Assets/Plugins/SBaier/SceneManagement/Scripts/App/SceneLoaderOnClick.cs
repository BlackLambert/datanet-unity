

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SBaier.SceneManagement
{
	public class SceneLoaderOnClick : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }
		[SerializeField]
		private string _sceneName = string.Empty;
		public string SceneName { get { return _sceneName; } }
		[SerializeField]
		private bool _additive = true;
		public bool Additive { get { return _additive; } }


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
			LoadSceneMode mode = _additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
			SceneManager.LoadScene(_sceneName, mode);
		}
	}
}