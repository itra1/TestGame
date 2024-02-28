using UnityEngine;

namespace App.Providers.Maps.Settings {
	[CreateAssetMenu(fileName = "MapSettings", menuName = "App/Map/Settings/Create Settings")]
	public class MapSettings :ScriptableObject, IMapSettings {
		[SerializeField] private float _cellSize;
		[SerializeField] private Vector2Int _cellsCount;
		[SerializeField] private CellVariation[] _cellVariations;
		[SerializeField] private SpriteRenderer _gameItem;

		public float CellSize => _cellSize;

		public Vector2Int CellsCount => _cellsCount;

		public SpriteRenderer GameItem => _gameItem;

		public CellVariation[] CellVariations => _cellVariations;
	}
}
