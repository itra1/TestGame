using App.Helpers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Listeners {
	public class WorldClickListener :IWorldClickListener {
		public void ScreenClick(PointerEventData eventData) {
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
