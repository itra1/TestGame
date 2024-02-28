using UnityEngine;

namespace App.Providers.Map.Settings {
	[CreateAssetMenu(fileName = "MapSettiings", menuName = "App/Map/Settings/Create Settiings")]
	public class MapSettings :ScriptableObject {
		[SerializeField] private Vector2 _mapSize;
		[SerializeField] private Vector2Int _cellsCount;
	}
}
