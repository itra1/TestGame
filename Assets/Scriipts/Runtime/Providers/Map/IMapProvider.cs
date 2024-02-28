using App.Providers.Map.Cells;
using UnityEngine;

namespace App.Providers.Map {
	public interface IMapProvider {

		bool ExistsOpenCell { get; }

		void GenerateMap();
		int GetCostPath(ICell currentPlayerCell, ICell cellToMove);
		ICell GetNearestCell(Vector3 position);
		ICell GetRandomOpenCell();
	}
}
