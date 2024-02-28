using App.Providers.Maps.Settings;
using UnityEngine;

namespace App.Providers.Maps.Cells {
	public class Cell :ICell {

		private SpriteRenderer _actor;
		private ICellVariation _variant;
		private Vector2Int _coordinate;

		public int Cost => _variant == null ? -1 : _variant.Cost;
		public bool IsBlock => _variant == null ? true : _variant.IsBlock;
		public object Locker { get; set; }
		public bool IsLock => Locker != null;
		public Vector3 WorldPosition {
			get {
				if (_actor == null)
					throw new System.NullReferenceException("Cell no exists view");
				return _actor.transform.position;
			}
		}

		public Vector2Int Coordinate => _coordinate;

		public Cell(SpriteRenderer renderer, ICellVariation variant) {
			SetSpriteRenderer(renderer);
			SetVariant(variant);
		}

		public void Dispose() {
			if (_actor != null) {
				MonoBehaviour.Destroy(_actor.gameObject);
				_actor = null;
			}
			_variant = null;
		}

		public void SetVariant(ICellVariation variant) {
			_variant = variant;
			ConfirmCellVariant();
		}

		public void SetSpriteRenderer(SpriteRenderer spriteRenderer) {
			_actor = spriteRenderer;
			ConfirmCellVariant();
		}

		private void ConfirmCellVariant() {
			if (_actor == null || _variant == null)
				return;
			_actor.color = _variant.Color;

		}

		public void SetCoordinate(Vector2Int coordinate) {
			_coordinate = coordinate;
		}

		public bool InOneLine(ICell targetCell) {
			return _coordinate.x == targetCell.Coordinate.x || _coordinate.y == targetCell.Coordinate.y;
		}
	}
}
