using App.Providers.Maps.Cells;
using App.Providers.Players.Common;

namespace App.Providers.Players {
	public interface IPlayerProvider {
		IPlayer Player { get; }
		ICell GetPlayerCell();
		void SpawnPlayer();
	}
}
