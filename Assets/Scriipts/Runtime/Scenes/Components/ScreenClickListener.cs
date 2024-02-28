using App.Base;
using App.Helpers;
using App.Listeners;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace App.Scenes.Components {
	public class ScreenClickListener :MonoBehaviour, IPointerClickHandler, IInjection {
		private IWorldClickListener _worldClickListener;

		[Inject]
		public void Initiate(IWorldClickListener worldClickListener) {
			_worldClickListener = worldClickListener;
		}
		public void OnPointerClick(PointerEventData eventData) {
			Vector3 worldposition = Camera.main.ScreenToWorldPoint(eventData.position);

			RaycastHit2D hit = Physics2D.Raycast(worldposition, Camera.main.transform.forward, 100);
			if (hit.collider != null) {
				if (hit.collider.TryGetComponent<IClickEventer>(out IClickEventer hitObject)) {

					hitObject.ClickPointer(hit.point);
				}
			}
		}
	}
}
