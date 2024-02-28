using System.Collections.Generic;
using App.Providers.Maps.Cells;
using App.Providers.Maps.Settings;
using App.Scenes.Interfaces;
using UnityEngine;

namespace App.Providers.Maps.Common {
	public class Map :IMap {
		private List<ICell> _cells = new();
		private IMapSettings _setting;
		private IWorldParent _worldParent;
		public bool ExistsOpenCell => _cells.Exists(x => !x.IsBlock);

		public Map(IMapSettings settings, IWorldParent worldParent) {
			if (settings == null)
				throw new System.NullReferenceException("Need settings");
			_setting = settings;
			_worldParent = worldParent;
		}

		public Vector2 MapSize => new(_setting.CellSize * _setting.CellsCount.x, _setting.CellSize * _setting.CellsCount.y);

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

		public void MakeMap() {

			if (_setting.CellsCount.x < 2 || _setting.CellsCount.y < 2)
				throw new System.ArgumentException("Серьезно? Хотя 2 по обоим сторонам поставьте");
			// проверку на слишком малый размер ячейки делать не буду, на вашей совести

			// Не вижу пока смысла выносить в фабрику, хотя надо было бы

			// Конечно не правильно, что я полностью их создаю, вместе с игровыми обьектами, а потом в случае неудачной проверке уничтожаю с обьетами, лучше разделить, но и так по времени затянул
			do {
				ClearArrays();
				MakeArrays();
			} while (GetRandomOpenCell() == null);
		}

		private void MakeArrays() {
			int allCountCells = _setting.CellsCount.x * _setting.CellsCount.y;
			Vector3 startSpawnPosition = new(-(MapSize.x / 2 - _setting.CellSize / 2), MapSize.y / 2 - _setting.CellSize / 2);
			for (int i = 0; i < allCountCells; i++) {
				CellVariation cellVariant = _setting.CellVariations[Random.Range(0, _setting.CellVariations.Length)];
				Vector2Int gridPosition = new(i % _setting.CellsCount.x, i / _setting.CellsCount.x);
				Vector3 itemPosition = startSpawnPosition + new Vector3(gridPosition.x * _setting.CellSize, -gridPosition.y * _setting.CellSize, 0);
				SpriteRenderer gameItem = MonoBehaviour.Instantiate<SpriteRenderer>(_setting.GameItem, _worldParent != null ? _worldParent.WorldParent : null);
				gameItem.transform.localScale = Vector3.one * _setting.CellSize;
				gameItem.transform.position = itemPosition;
				Cell instanceCell = new Cell(gameItem, cellVariant);
				instanceCell.SetCoordinate(gridPosition);
				_cells.Add(instanceCell);
			}
		}

		private void ClearArrays() {
			for (int i = 0; i < _cells.Count; i++) {
				_cells[i].Dispose();
			}
			_cells.Clear();
		}
	}
}
