using UnityEngine;
using Zenject;

public class FragmentTemplateListElementContentInstaller : MonoInstaller
{
	[SerializeField]
	private GameObject _base;
	public GameObject Base { get { return _base; } }

    public override void InstallBindings()
    {

    }
}