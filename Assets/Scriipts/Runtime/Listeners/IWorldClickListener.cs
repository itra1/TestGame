using UnityEngine.EventSystems;

namespace App.Listeners {
	public interface IWorldClickListener {

		public void ScreenClick(PointerEventData eventData);
	}
}