using App.Providers.Map.Cells;
using App.Providers.Players.Actors;
using UnityEngine;

namespace App.Providers.Players.Common {
	public class Player :IPlayer {
		[SerializeField] private Vector2Int _cellCosition;
		[SerializeField] private IPlayerActor _actor;

		public ICell CellPosition { get; private set; }
		public IPlayerActor Actor => _actor;

		public void SetActor(IPlayerActor actor) {
			_actor = actor;
		}

		public void SetPositionCell(ICell positionCell) {
			if (CellPosition != null)
				CellPosition.Locker = null;
			CellPosition = positionCell;
			CellPosition.Locker = true;
			(_actor as Component).transform.position = CellPosition.WorldPosition;
		}
	}
}
