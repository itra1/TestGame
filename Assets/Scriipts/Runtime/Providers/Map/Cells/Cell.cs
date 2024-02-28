using UnityEngine;

namespace App.Providers.Map.Cells {
	public class Cell :ICell {
		public int Cost { get; set; }
		public Vector2 Position { get; }
	}
}
