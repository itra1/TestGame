using App.Providers.Maps.Cells;
using App.Providers.Players.Actors;
using UnityEngine;

namespace App.Providers.Players.Common {
	public interface IPlayer {
		ICell CellPosition { get; }
		IPlayerActor Actor { get; }

		void SetActor(IPlayerActor actor);
		void SetPositionCell(ICell positionCell);
		void MoveToWorldPosition(Vector3 position);
	}
}
