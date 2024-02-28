using UnityEngine;

namespace App.Providers.Map.Settings {
	public interface IMapSettings {
		public float CellSize { get; }
		public Vector2Int CellsCount { get; }
	}
}
