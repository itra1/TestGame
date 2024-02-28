using App.Providers.Map.Cells;

namespace App.Providers.Player.Common {
	public interface IPlayer {
		ICell CellPosition { get; }
	}
}
