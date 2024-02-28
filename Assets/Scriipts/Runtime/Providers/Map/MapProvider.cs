using App.Providers.Map.Settings;
using UnityEngine;

namespace App.Providers.Map {
	public class MapProvider :IMapProvider {

		private IMapSettings _settings;

		public MapProvider(IMapSettings settings) {
			_settings = settings;

			GenerateMap();
		}

		public void GenerateMap() {
			float scaleX = _settings.CellSize * _settings.CellsCount.x;
			float scaleY = _settings.CellSize * _settings.CellsCount.y;
			Vector3 startSpawnPosition = new(-(scaleX / 2 - _settings.CellSize / 2), scaleY / 2 - _settings.CellSize / 2);
			int allCountCells = _settings.CellsCount.x * _settings.CellsCount.y;
			Debug.Log("call coune" + allCountCells);
			for (int i = 0; i < allCountCells; i++) {
				CellVariation cellVariany = _settings.CellVariations[Random.Range(0, _settings.CellVariations.Length)];
				Vector2Int gridPosition = new(i % _settings.CellsCount.x, i / _settings.CellsCount.x);
				Vector3 itemPosition = startSpawnPosition + new Vector3(gridPosition.x * _settings.CellSize, -gridPosition.y * _settings.CellSize, 0);
				SpriteRenderer gameItem = MonoBehaviour.Instantiate<SpriteRenderer>(_settings.GameItem);
				gameItem.transform.localScale = Vector3.one * _settings.CellSize;
				gameItem.transform.position = itemPosition;
			}

		}
	}
}
