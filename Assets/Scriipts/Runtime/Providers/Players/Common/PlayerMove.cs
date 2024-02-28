using App.Providers.Maps;
using App.Providers.Maps.Cells;
using UnityEngine;
using Zenject;

namespace App.Providers.Players.Common {
	public partial class Player {
		private IMapProvider _mapProvider;

		[Inject]
		public void MoveInitialize(IMapProvider mapProvider) {
			_mapProvider = mapProvider;
		}

		public void SetPositionCell(ICell positionCell) {
			if (CellPosition != null)
				CellPosition.Locker = null;
			CellPosition = positionCell;
			CellPosition.Locker = true;
			(_actor as Component).transform.position = CellPosition.WorldPosition;
		}

		public void MoveToWorldPosition(Vector3 position) {

			ICell cell = _mapProvider.Map.GetNearestCell(position);
			SetPositionCell(cell);
		}

	}
}
