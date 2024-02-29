using System.Collections;
using App.Base;
using App.Providers.Game;
using App.Settings;
using TMPro;
using UnityEngine;
using Zenject;

namespace App.Scenes.Components {
	public class NewDayLabel :MonoBehaviour, IInjection {
		[SerializeField] private TMP_Text _newDayLabel;

		private IGameProvider _gameProvider;
		private float _closeTime;
		private IAppSettings _appSesion;

		[Inject]
		public void Initiate(IAppSettings appSession, IGameProvider gameProvider) {
			_gameProvider = gameProvider;
			_gameProvider.GameStart_Event.AddListener(GameStart);
			_newDayLabel.gameObject.SetActive(false);
			_appSesion = appSession;
		}

		public void OnDisable() {
			if (_gameProvider != null)
				_gameProvider.GameStart_Event.RemoveListener(GameStart);
		}

		private void GameStart() {
			Providers.Game.Common.IGameSession gameSession = _gameProvider.GameSession;
			gameSession?.StepCountChange_Event.AddListener(ChangeDays);
		}

		private void ChangeDays(int stepCount) {

			if (_appSesion.StepInDays == stepCount)
				VisibleLabel();
		}

		private void VisibleLabel() {
			_closeTime = Time.realtimeSinceStartup + 2;
			if (!_newDayLabel.gameObject.activeSelf)
				StartCoroutine(VisibleLabelCoroutine());
		}

		private IEnumerator VisibleLabelCoroutine() {
			_newDayLabel.gameObject.SetActive(true);
			while (_closeTime > Time.realtimeSinceStartup)
				yield return null;
			_newDayLabel.gameObject.SetActive(false);
		}
	}
}
