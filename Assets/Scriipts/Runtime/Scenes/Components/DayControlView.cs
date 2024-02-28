using App.Base;
using App.Providers.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scenes.Components {
	public class DayControlView :MonoBehaviour, IInjection {
		[SerializeField] private TMP_Text _stepLabel;
		[SerializeField] private Button _nextDayButton;

		private IGameProvider _gameProvider;

		[Inject]
		public void Initiate(IGameProvider gameProvider) {
			_gameProvider = gameProvider;
			_gameProvider.GameStart_Event.AddListener(GameStart);
		}
		public void Awake() {
			_nextDayButton.onClick.RemoveAllListeners();
			_nextDayButton.onClick.AddListener(NextDayButtonTouch);
		}

		public void OnDisable() {
			if (_gameProvider != null)
				_gameProvider.GameStart_Event.RemoveListener(GameStart);
		}

		private void GameStart() {
			Providers.Game.Common.IGameSession gameSession = _gameProvider.GameSession;
			gameSession?.StepCountChange_Event.AddListener(ChangeDays);
			SetSteps(gameSession.CurrentSteps);
		}

		private void ChangeDays(int stepCount) {
			SetSteps(stepCount);
		}

		private void SetSteps(int stepcount) {
			_stepLabel.text = $"Step in day: {stepcount}";
		}

		private void NextDayButtonTouch() {
			_gameProvider.NextDay();
		}
	}
}
