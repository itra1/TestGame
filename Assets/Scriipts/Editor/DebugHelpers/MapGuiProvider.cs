using UnityEngine;
using Zenject;

namespace AppEditor.DebugHelpers {
	internal class MapGuiProvider :IGuiRenderable {
		public void GuiRender() {
			Debug.Log("gizmos");
			Gizmos.DrawLine(Vector2.zero, Vector2.one * 100);
		}
	}
}
