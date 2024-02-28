using App.Providers.Map;
using App.Scenes;
using Zenject;

namespace App.Installers {
	public class CoreInstall :MonoInstaller {

		public override void InstallBindings() {

			Container.BindInterfacesAndSelfTo<SceneProvider>().FromInstance(FindAnyObjectByType<SceneProvider>());

			Container.BindInterfacesAndSelfTo<MapProvider>().AsSingle().NonLazy();

			ResolveAll();
		}

		private void ResolveAll() {
			Container.Resolve<IMapProvider>();
		}

	}
}