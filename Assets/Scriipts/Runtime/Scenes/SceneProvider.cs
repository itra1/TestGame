using UnityEngine;

namespace App.Scenes {
	public class SceneProvider :MonoBehaviour, ISceneProvider {

		[SerializeField] private Transform _world;
		[SerializeField] private Transform _screens;

		public Transform WorldParent => _world;
	}
}
