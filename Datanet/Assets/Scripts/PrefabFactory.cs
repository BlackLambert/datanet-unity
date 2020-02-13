using Zenject;
using UnityEngine;
using System;

namespace SBaier
{
	/// <summary>
	/// Most default prefab factory.
	/// Use this factory for basic construction of GameObjects.
	/// A reference to the prefab is necessary.
	/// </summary>
	public class PrefabFactory
	{
		[Inject]
		private DiContainer _container;

		/// <summary>
		/// Creates instance of <paramref name="prefab"/>.
		/// Dependencies will be injected.
		/// </summary>
		/// <typeparam name="TPrefab">A <see cref="Component"/></typeparam>
		/// <param name="prefab">The prefab to instantiate.</param>
		/// <returns>An instance of <paramref name="prefab"/></returns>
		public TPrefab Create<TPrefab>(TPrefab prefab, DiContainer container = null)
			where TPrefab : UnityEngine.Component
		{
			return createInstance(prefab, new Parameter[0], container == null ? _container : container);
		}


		public TPrefab Create<TPrefab>(TPrefab prefab, Parameter[] objects, DiContainer container = null)
			where TPrefab : UnityEngine.Component
		{
			return createInstance(prefab, objects, container == null ? _container : container);
		}

		private TResult createInstance<TResult>(TResult prefab, Parameter[] parameters,
			DiContainer container)
			where TResult : UnityEngine.Component
		{
			DiContainer subContainer = container.CreateSubContainer();
			foreach (Parameter parameter in parameters)
				subContainer.Bind(parameter.Type).To(parameter.Target.GetType()).FromInstance(parameter.Target).AsSingle();
			return subContainer.InstantiatePrefabForComponent<TResult>(prefab);
		}


		public class Parameter
		{
			public object Target { get; private set; }
			public Type Type { get; private set; }

			public Parameter(object target, Type type)
			{
				Target = target;
				Type = type;
			}

			public Parameter(object target)
			{
				Target = target;
				Type = Target.GetType();
			}
		}
	}
}