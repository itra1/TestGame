
using App.Providers.Map;
using App.Providers.Player.Common;

namespace App.Providers.Player {
	public class PlayerProvider :IPlayerProvider {

		private IMapProvider _mapProvider;
		private IPlayer _player;

		public PlayerProvider(IMapProvider mapProvider) {
			_mapProvider = mapProvider;
		}

		public void SpawnPlayer() {
		}
	}
}
