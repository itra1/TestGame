using UnityEngine;

namespace App.Providers.Maps.Settings {
	public interface ICellVariation {
		public int Cost { get; }
		public Color Color { get; }
		public bool IsBlock { get; }
	}
}
