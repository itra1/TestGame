using App.Helpers;
using App.Providers.Game;
using UnityEngine;
using Zenject;

namespace App.Scenes.Actors {
	public class MapGroundActor :MonoBehaviour, IClickEventer {

		private IGameProvider _gameProvider;

		[Inject]
		public void Initiate(IGameProvider gameProvider) {
			_gameProvider = gameProvider;
		}

		public void ClickPointer(Vector3 position) {
			Providers.Game.Common.IGameSession gameSession = _gameProvider.GameSession;
			gameSession.GroundClick(position);
		}
	}
}
