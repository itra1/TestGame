using App.Providers.Maps.Cells;
using UnityEngine;

namespace App.Providers.Maps.Common {
	public interface IMap {
		bool ExistsOpenCell { get; }
		Vector2 MapSize { get; }

		void MakeMap();

		int GetCostPath(ICell currentPlayerCell, ICell cellToMove);
		ICell GetNearestCell(Vector3 position);
		ICell GetRandomOpenCell();
	}
}