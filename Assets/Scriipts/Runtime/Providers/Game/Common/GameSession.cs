using App.Providers.Map;
using App.Providers.Map.Cells;
using App.Providers.Players;
using UnityEngine;
using Zenject;

namespace App.Providers.Game.Common {
	public class GameSession :IGameSession {

		private IMapProvider _mapProvider;
		private IPlayerProvider _playerProvider;

		public bool IsStart { get; private set; }

		[Inject]
		public void Initiate(IMapProvider mapProvider, IPlayerProvider playerProvider) {
			_mapProvider = mapProvider;
			_playerProvider = playerProvider;
		}

		public void RunGame() {
			IsStart = true;
			_mapProvider.GenerateMap();
			_playerProvider.SpawnPlayer();
		}

		public void StopGame() {
			IsStart = false;
		}

		public void GroundClick(Vector3 position) {
			if (!IsStart)
				return;

			ICell cellToMove = _mapProvider.GetNearestCell(position);
			if (cellToMove.IsBlock || cellToMove.IsLock)
				return;
			ICell currentPlayerCell = _playerProvider.GetPlayerCell();
			if (!currentPlayerCell.InOneLine(cellToMove))
				return;

			int costPath = _mapProvider.GetCostPath(currentPlayerCell, cellToMove);
			Debug.Log(costPath);
			if (costPath < 0)
				return;
			_playerProvider.MoveToWorldPosition(position);
		}
	}
}
