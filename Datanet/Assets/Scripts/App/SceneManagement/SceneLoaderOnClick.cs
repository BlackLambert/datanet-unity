

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SBaier.Datanet
{
	public class SceneLoaderOnClick : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;
		[SerializeField]
		private string _sceneName = string.Empty;
		[SerializeField]
		private bool _additive = true;
		

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