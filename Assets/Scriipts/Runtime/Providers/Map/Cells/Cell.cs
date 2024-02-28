using System;
using App.Providers.Map.Settings;
using UnityEngine;

namespace App.Providers.Map.Cells {
	public class Cell :ICell, IDisposable {

		private SpriteRenderer _gameCell;
		private ICellVariation _variant;

		public int Cost => _variant == null ? -1 : _variant.Cost;
		public bool isBlock => _variant == null ? true : _variant.IsBlock;
		public Vector2 Position { get; }

		public Cell() {

		}

		public Cell(SpriteRenderer renderer, ICellVariation variant) {
			SetSpriteRenderer(renderer);
			SetVariant(variant);
		}

		public void Dispose() {
			if (_gameCell != null) {
				MonoBehaviour.Destroy(_gameCell.gameObject);
				_gameCell = null;
			}
			_variant = null;
		}

		public void SetVariant(ICellVariation variant) {
			_variant = variant;
			ConfirmCellVariant();
		}

		public void SetSpriteRenderer(SpriteRenderer spriteRenderer) {
			_gameCell = spriteRenderer;
			ConfirmCellVariant();
		}

		private void ConfirmCellVariant() {
			if (_gameCell == null || _variant == null)
				return;
			_gameCell.color = _variant.Color;

		}

	}
}
