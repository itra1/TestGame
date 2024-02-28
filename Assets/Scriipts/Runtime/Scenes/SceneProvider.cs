using UnityEngine;

namespace App.Scenes {
	public class SceneProvider :MonoBehaviour, ISceneProvider {

		[SerializeField] private Transform _world;
		[SerializeField] private Transform _screens;
		[SerializeField] private BoxCollider2D _mapGround;

		public Transform WorldParent => _world;

		public BoxCollider2D MapGround => _mapGround;
	}
}
