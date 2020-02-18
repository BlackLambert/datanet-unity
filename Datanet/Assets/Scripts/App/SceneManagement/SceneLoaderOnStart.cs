

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace SBaier.Datanet
{
	public class SceneLoaderOnStart : MonoBehaviour
	{
		[SerializeField]
		private List<SceneToLaod> _scenesToLoad = null;


		protected virtual void Start()
		{
			foreach (SceneToLaod scene in _scenesToLoad)
			{
				LoadSceneMode mode = scene.Additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
				SceneManager.LoadScene(scene.SceneName, mode);
			}
		}

		[Serializable]
		public class SceneToLaod
		{
			[SerializeField]
			private string _sceneName = string.Empty;
			public string SceneName { get { return _sceneName; } }
			[SerializeField]
			private bool _additive = true;
			public bool Additive { get { return _additive; } }
		}
	}
}