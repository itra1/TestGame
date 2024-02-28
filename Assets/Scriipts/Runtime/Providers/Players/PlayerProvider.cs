
using App.Providers.Maps;
using App.Providers.Maps.Cells;
using App.Providers.Players.Actors;
using App.Providers.Players.Common;
using App.Settings;
using UnityEngine;
using Zenject;

namespace App.Providers.Players {
	public class PlayerProvider :IPlayerProvider {

		private IMapProvider _mapProvider;
		private IPlayer _player;
		private IAppSettings _appSettings;
		private DiContainer _container;
		public IPlayer Player => _player;

		public PlayerProvider(DiContainer container, IAppSettings appSettings, IMapProvider mapProvider) {
			_container = container;
			_appSettings = appSettings;
			_mapProvider = mapProvider;
		}

		public ICell GetPlayerCell() {
			return _player.CellPosition;
		}

		public void SpawnPlayer() {
			if (_appSettings.PlayerActor == null)
				throw new System.NullReferenceException();

			if (_player == null)
				_player = new Player();
			_container.Inject(_player);

			_player.SetActor(MonoBehaviour.Instantiate<PlayerActor>(_appSettings.PlayerActor));

			ICell cell = _mapProvider.Map.GetRandomOpenCell();
			Debug.Log(cell);
			_player.SetPositionCell(cell);
		}
	}
}
