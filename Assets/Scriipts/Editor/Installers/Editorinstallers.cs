using App.Providers.Map.Settings;
using AppEditor.DebugHelpers;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace AppEditor.installers {
	[InitializeOnLoad]
	public class Editorinstallers :EditorStaticInstaller<Editorinstallers> {

		public Editorinstallers() {
			Debug.Log("exec");
			EditorApplication.QueuePlayerLoopUpdate();
			Install();
		}

		public override void InstallBindings() {

			Debug.Log("exec");
			Container.BindInterfacesAndSelfTo<MapSettings>().FromResource("MapSettings");
			Container.BindInterfacesAndSelfTo<MapGuiProvider>().AsSingle().NonLazy();
			ResolveAll();
		}

		private void ResolveAll() {
			Container.Resolve<IMapSettings>();
		}
	}
}
