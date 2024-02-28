using App.Providers.Game.Common;
using App.Providers.Map;
using App.Providers.Players;
using Zenject;

namespace App.Providers.Game {
	public class GameProvider :IGameProvider {
		private DiContainer _contaider;
		private IGameSession _gameSession;
		public GameProvider(DiContainer contaider, IMapProvider mapProvider, IPlayerProvider playerProvider) {
			_contaider = contaider;
		}

		public IGameSession GameSession => _gameSession;

		public void RunGame() {
			_gameSession = new GameSession();
			_contaider.Inject(_gameSession);
			_gameSession.RunGame();
		}

	}
}
