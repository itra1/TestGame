using System.Collections.Generic;
using App.Providers.Map.Cells;
using App.Providers.Map.Common;
using App.Providers.Map.Settings;
using UnityEngine;

namespace App.Providers.Map {
	public class MapProvider :IMapProvider {

		private IMapSettings _settings;
		private IMapGround _mapGround;
		private List<ICell> _cells = new();

		public bool ExistsOpenCell => _cells.Exists(x => !x.IsBlock);

		public MapProvider(IMapSettings settings, IMapGround mapGround) {
			_settings = settings;
			_mapGround = mapGround;
		}

		public void GenerateMap() {
			float scaleX = _settings.CellSize * _settings.CellsCount.x;
			float scaleY = _settings.CellSize * _settings.CellsCount.y;
			Vector3 startSpawnPosition = new(-(scaleX / 2 - _settings.CellSize / 2), scaleY / 2 - _settings.CellSize / 2);
			int allCountCells = _settings.CellsCount.x * _settings.CellsCount.y;
			_mapGround.MapGround.size = new(scaleX, scaleY);

			for (int i = 0; i < allCountCells; i++) {
				CellVariation cellVariant = _settings.CellVariations[Random.Range(0, _settings.CellVariations.Length)];
				Vector2Int gridPosition = new(i % _settings.CellsCount.x, i / _settings.CellsCount.x);
				Vector3 itemPosition = startSpawnPosition + new Vector3(gridPosition.x * _settings.CellSize, -gridPosition.y * _settings.CellSize, 0);
				SpriteRenderer gameItem = MonoBehaviour.Instantiate<SpriteRenderer>(_settings.GameItem);
				gameItem.transform.localScale = Vector3.one * _settings.CellSize;
				gameItem.transform.position = itemPosition;
				Cell instanceCell = new Cell(gameItem, cellVariant);
				instanceCell.SetCoordinate(gridPosition);
				_cells.Add(instanceCell);
			}
		}

		public ICell GetRandomOpenCell() {
			if (!ExistsOpenCell)
				return null;
			List<ICell> openCells = _cells.FindAll(x => !x.IsBlock);
			return openCells[Random.Range(0, openCells.Count)];
		}

		private ICell GetCellByCoordinate(Vector2Int coordinate) {
			return _cells.Find(x => x.Coordinate == coordinate);
		}

		public ICell GetNearestCell(Vector3 position) {
			ICell nearest = _cells[0];
			for (int i = 0; i < _cells.Count; i++) {
				if ((_cells[i].WorldPosition - position).sqrMagnitude < (nearest.WorldPosition - position).sqrMagnitude)
					nearest = _cells[i];
			}
			return nearest;
		}

		public int GetCostPath(ICell cellFrom, ICell cellTo) {
			Vector2Int delta = cellTo.Coordinate - cellFrom.Coordinate;
			Vector2Int increment = new(
			delta.x == 0 ? 0 : (int)Mathf.Sign(delta.x),
			delta.y == 0 ? 0 : (int)Mathf.Sign(delta.y));
			Vector2Int currentCoordinate = cellFrom.Coordinate;
			int allCost = 0;
			while (currentCoordinate != cellTo.Coordinate) {
				currentCoordinate += increment;
				ICell newCell = GetCellByCoordinate(currentCoordinate);
				if (newCell.IsBlock || newCell.IsLock)
					return -1;
				allCost += newCell.Cost;
			}
			return allCost;
		}
	}
}
