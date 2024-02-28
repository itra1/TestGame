using UnityEngine;

namespace App.Scenes {
	public class SceneProvider :MonoBehaviour, ISceneProvider {

		[SerializeField] private Transform _world;

		public Transform WorldParent => _world
	}
}
