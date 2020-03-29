using SBaier.Storage;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	[CreateAssetMenu(fileName = "FragmentInfosInstaller", menuName = "DataNet/FragmentInfosInstaller")]
	public class FragmentInfosInstaller : ScriptableObjectInstaller<FragmentInfosInstaller>
	{
		[SerializeField]
		private FragmentInfo[] _infos = null;

		public override void InstallBindings()
		{
			Container.Bind(typeof(Repository<FragmentInfos>), typeof(FragmentInfosRepository)).
				To<FragmentInfosRepositoryImpl>().FromInstance(createFragmentInfosRepository()).AsSingle();
		}

		private FragmentInfosRepositoryImpl createFragmentInfosRepository()
		{
			FragmentInfosRepositoryImpl repository = new FragmentInfosRepositoryImpl();
			FragmentInfos infos = new FragmentInfos();
			foreach (FragmentInfo info in _infos)
				infos.Add(info);
			repository.Store(infos);
			return repository;
		}
	}
}