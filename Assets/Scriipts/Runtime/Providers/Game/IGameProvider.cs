using App.Providers.Game.Common;
using UnityEngine.Events;

namespace App.Providers.Game {
	public interface IGameProvider {
		void RunGame();
		void NextDay();

		UnityEvent GameStart_Event { get; }

		IGameSession GameSession { get; }
	}
}
