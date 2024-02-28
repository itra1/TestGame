using App.Providers.Maps;
using App.Providers.Maps.Cells;
using App.Providers.Players;
using App.Settings;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace App.Providers.Game.Common {
	public class GameSession :IGameSession {
		public UnityEvent<int> StepCountChange_Event { get; set; } = new();

		private IAppSettings _appSesion;
		private IMapProvider _mapProvider;
		private IPlayerProvider _playerProvider;

		public int CurrentSteps { get; private set; }

		public bool IsStart { get; private set; }

		[Inject]
		public void Initiate(IAppSettings appSession, IMapProvider mapProvider, IPlayerProvider playerProvider) {
			_appSesion = appSession;
			_mapProvider = mapProvider;
			_playerProvider = playerProvider;
		}

		public void RunGame() {
			IsStart = true;
			_mapProvider.GenerateMap();
			_playerProvider.SpawnPlayer();
			SetSteps(_appSesion.StepInDays);
		}

		public void StopGame() {
			IsStart = false;
		}

		public void GroundClick(Vector3 position) {
			if (!IsStart)
				return;

			ICell cellToMove = _mapProvider.Map.GetNearestCell(position);
			if (cellToMove.IsBlock || cellToMove.IsLock)
				return;
			ICell currentPlayerCell = _playerProvider.GetPlayerCell();
			if (!currentPlayerCell.InOneLine(cellToMove))
				return;

			int costPath = _mapProvider.Map.GetCostPath(currentPlayerCell, cellToMove);
			if (costPath < 0)
				return;
			if (CurrentSteps < costPath)
				return;
			SetSteps(CurrentSteps - costPath);
			_playerProvider.Player.MoveToWorldPosition(position);
		}

		public void NextDay() {
			SetSteps(_appSesion.StepInDays);
		}
		private void SetSteps(int stepsCount) {
			CurrentSteps = stepsCount;
			StepCountChange_Event?.Invoke(CurrentSteps);
		}
	}
}
