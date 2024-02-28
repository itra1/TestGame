using App.Providers.Map.Cells;
using UnityEngine;

namespace App.Providers.Players {
	public interface IPlayerProvider {
		ICell GetPlayerCell();
		void MoveToWorldPosition(Vector3 position);
		void SpawnPlayer();
		void WordClick(Vector3 position) {

		}
	}
}
