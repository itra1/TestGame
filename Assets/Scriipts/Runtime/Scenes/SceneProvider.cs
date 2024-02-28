using App.Base;
using UnityEngine;
using Zenject;

namespace App.Scenes {
	public class SceneProvider :MonoBehaviour, ISceneProvider {

		[SerializeField] private Transform _world;
		[SerializeField] private Transform _screens;
		[SerializeField] private BoxCollider2D _mapGround;

		[Inject]
		public void Initiate(DiContainer container) {

			// провайдер скринов не успеваю, так что так
			IInjection[] screenComponents = _screens.GetComponentsInChildren<IInjection>();
			foreach (IInjection item in screenComponents) {
				container.Inject(item);
			}
		}

		public Transform WorldParent => _world;

		public BoxCollider2D MapGround => _mapGround;
	}
}
