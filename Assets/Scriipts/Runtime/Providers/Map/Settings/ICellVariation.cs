using UnityEngine;

namespace App.Providers.Map.Settings {
	public interface ICellVariation {
		public int Cost { get; }
		public Color Color { get; }
		public bool IsBlock { get; }
	}
}
