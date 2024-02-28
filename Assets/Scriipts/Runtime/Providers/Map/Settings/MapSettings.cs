using UnityEngine;

namespace App.Providers.Map.Settings {
	[CreateAssetMenu(fileName = "MapSettings", menuName = "App/Map/Settings/Create Settings")]
	public class MapSettings :ScriptableObject, IMapSettings {
		[SerializeField] private float _cellSize;
		[SerializeField] private Vector2Int _cellsCount;
		[SerializeField] private CellVariation[] _cellVariations;

		public float CellSize => _cellSize;

		public Vector2Int CellsCount => _cellsCount;
	}
}
