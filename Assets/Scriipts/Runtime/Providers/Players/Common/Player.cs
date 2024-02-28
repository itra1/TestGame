using App.Providers.Maps.Cells;
using App.Providers.Players.Actors;
using UnityEngine;

namespace App.Providers.Players.Common {
	public partial class Player :IPlayer {
		[SerializeField] private Vector2Int _cellCosition;
		[SerializeField] private IPlayerActor _actor;

		public ICell CellPosition { get; private set; }
		public IPlayerActor Actor => _actor;

		public void SetActor(IPlayerActor actor) {
			_actor = actor;
		}

	}
}
