using App.Providers.Map;
using App.Providers.Players;

namespace App.Providers.Game {
	public class GameProvider :IGameProvider {
		private IMapProvider _mapProvider;
		private IPlayerProvider _playerProvider;
		public GameProvider(IMapProvider mapProvider, IPlayerProvider playerProvider) {
			_mapProvider = mapProvider;
			_playerProvider = playerProvider;
		}
		public void RunGame() {
			_mapProvider.GenerateMap();
			_playerProvider.SpawnPlayer();
		}
	}
}
