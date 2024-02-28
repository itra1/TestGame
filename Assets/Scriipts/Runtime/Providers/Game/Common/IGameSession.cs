using UnityEngine;

namespace App.Providers.Game.Common {
	public interface IGameSession {
		void RunGame();
		void GroundClick(Vector3 position);

	}
}