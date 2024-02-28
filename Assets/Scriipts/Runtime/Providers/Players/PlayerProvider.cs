
using App.Providers.Map;
using App.Providers.Map.Cells;
using App.Providers.Players.Actors;
using App.Providers.Players.Common;
using App.Settings;
using UnityEngine;

namespace App.Providers.Players {
	public class PlayerProvider :IPlayerProvider {

		private IMapProvider _mapProvider;
		private IPlayer _player;
		private IAppSettings _appSettings;

		public PlayerProvider(IAppSettings appSettings, IMapProvider mapProvider) {
			_appSettings = appSettings;
			_mapProvider = mapProvider;
		}

		public ICell GetPlayerCell() {
			return _player.CellPosition;
		}

		public void MoveToWorldPosition(Vector3 position) {
			ICell cell = _mapProvider.GetNearestCell(position);
			_player.SetPositionCell(cell);
		}

		public void SpawnPlayer() {
			if (_appSettings.PlayerActor == null)
				throw new System.NullReferenceException();

			if (_player == null)
				_player = new Player();

			_player.SetActor(MonoBehaviour.Instantiate<PlayerActor>(_appSettings.PlayerActor));

			ICell cell = _mapProvider.GetRandomOpenCell();
			_player.SetPositionCell(cell);
		}
	}
}
