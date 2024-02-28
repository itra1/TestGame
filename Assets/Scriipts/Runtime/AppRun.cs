using App.Providers.Game;
using Zenject;

namespace App {
	internal class AppRun :IInitializable {
		private IGameProvider _gameProvider;
		public AppRun(IGameProvider gameProvider) {
			_gameProvider = gameProvider;
		}

		public void Initialize() {
			_gameProvider.RunGame();
		}
	}
}
