using UnityEngine;
using UnityEngine.Events;

namespace App.Providers.Game.Common {
	public interface IGameSession {
		UnityEvent<int> StepCountChange_Event { get; }
		public int CurrentSteps { get; }
		void RunGame();
		void GroundClick(Vector3 position);
		void NextDay();
	}
}