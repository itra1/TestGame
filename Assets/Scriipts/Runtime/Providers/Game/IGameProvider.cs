using App.Providers.Game.Common;

namespace App.Providers.Game {
	public interface IGameProvider {
		void RunGame();

		IGameSession GameSession { get; }
	}
}
