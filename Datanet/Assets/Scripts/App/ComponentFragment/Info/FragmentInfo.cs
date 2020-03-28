using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet
{
	[CreateAssetMenu(fileName = "FragmentInfo", menuName = "DataNet/FragmentInfo")]
	public class FragmentInfo : ScriptableObject
	{
		[SerializeField]
		private ComponentFragmentType _type = ComponentFragmentType.None;
		public ComponentFragmentType Type { get { return _type; } }
		[SerializeField]
		private string _name = "_MyFragment";
		public string Name { get {return _name; } }
		[SerializeField]
		private string _description = "_This is a new fragment";
		public string Description { get {return _description; } }
	}
}