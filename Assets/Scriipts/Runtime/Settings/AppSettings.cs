using App.Providers.Players.Actors;
using UnityEngine;

namespace App.Settings {
	[CreateAssetMenu(fileName = "AppSettings", menuName = "App/Settings/Create AppSettings")]
	public class AppSettings :ScriptableObject, IAppSettings {
		[SerializeField] private PlayerActor _playerActor;
		[SerializeField] private int _stepInDay;

		public PlayerActor PlayerActor => _playerActor;

		public int StepInDays => _stepInDay;
	}
}
