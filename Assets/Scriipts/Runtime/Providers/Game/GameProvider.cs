using App.Providers.Game.Common;
using App.Providers.Maps;
using App.Providers.Players;
using UnityEngine.Events;
using Zenject;

namespace App.Providers.Game {
	public class GameProvider :IGameProvider {
		private DiContainer _contaider;
		private IGameSession _gameSession;

		public IGameSession GameSession => _gameSession;

		public UnityEvent GameStart_Event { get; set; } = new();


		public GameProvider(DiContainer contaider, IMapProvider mapProvider, IPlayerProvider playerProvider) {
			_contaider = contaider;
		}

		public void NextDay() {
			_gameSession?.NextDay();
		}

		public void RunGame() {
			_gameSession = new GameSession();
			_contaider.Inject(_gameSession);
			_gameSession.RunGame();
			GameStart_Event?.Invoke();
		}

	}
}
