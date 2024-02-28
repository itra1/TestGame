using App.Providers.Map.Cells;
using App.Providers.Players.Actors;

namespace App.Providers.Players.Common {
	public interface IPlayer {
		ICell CellPosition { get; }
		IPlayerActor Actor { get; }

		void SetActor(IPlayerActor actor);
		void SetPositionCell(ICell positionCell);
	}
}
