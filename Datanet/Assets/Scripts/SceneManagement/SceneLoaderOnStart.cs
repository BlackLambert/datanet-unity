

using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace SBaier.Datanet
{
	public class SceneLoaderOnStart : MonoBehaviour
	{
		[SerializeField]
		private string _sceneName = "Default";
		[SerializeField]
		private bool _additive = true;


		protected virtual void Start()
		{
			LoadSceneMode mode = _additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
			SceneManager.LoadScene(_sceneName, mode);
		}
	}
}