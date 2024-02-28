using UnityEngine;

namespace App.Providers.Maps.Settings {
	[System.Serializable]
	public class CellVariation :ICellVariation {
		[SerializeField] private int _cost;
		[SerializeField] private Color _color;

		public int Cost => _cost;
		public Color Color => _color;
		public bool IsBlock => _cost < 0;
	}
}
