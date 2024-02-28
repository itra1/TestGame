using App.Helpers;
using UnityEngine;

namespace App.Scenes.Actors {
	public class MapGroundActor :MonoBehaviour, IClickEventer {

		public void ClickPointer(Vector3 position) {
			Debug.Log("Ground Click");
		}
	}
}
