using UnityEngine;

namespace App.Providers.Map.Settings {
	public interface IMapSettings {
		public Vector2 MapSize { get; }
		public Vector2Int CellsCount { get; }
	}
}
