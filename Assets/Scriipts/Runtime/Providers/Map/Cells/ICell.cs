using UnityEngine;

namespace App.Providers.Map.Cells {
	public interface ICell {
		int Cost { get; }
		Vector2 Position { get; }
	}
}
