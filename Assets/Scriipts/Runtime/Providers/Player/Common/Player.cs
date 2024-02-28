using App.Providers.Map.Cells;
using UnityEngine;

namespace App.Providers.Player.Common {
	public class Player :IPlayer {
		[SerializeField] private Vector2Int CellCosition;

		public ICell CellPosition { get; }
	}
}
