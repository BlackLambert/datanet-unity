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
			Container.Bind(typeof(Repository<FragmentInfos>), typeof(FragmentInfoRepository)).
				To<FragmentInfoRepositoryImpl>().FromInstance(createFragmentInfosRepository()).AsSingle();
		}

		private FragmentInfoRepositoryImpl createFragmentInfosRepository()
		{
			FragmentInfoRepositoryImpl repository = new FragmentInfoRepositoryImpl();
			FragmentInfos infos = new FragmentInfos();
			foreach (FragmentInfo info in _infos)
				infos.Add(info);
			repository.Store(infos);
			return repository;
		}
	}
}