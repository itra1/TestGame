using App.Providers.Map;
using App.Providers.Map.Settings;
using App.Providers.Player;
using App.Providers.UI.Windows;
using App.Scenes;
using Zenject;

namespace App.Installers {
	public class CoreInstall :MonoInstaller {

		public override void InstallBindings() {

			Container.BindInterfacesAndSelfTo<SceneProvider>().FromInstance(FindAnyObjectByType<SceneProvider>());

			Container.BindInterfacesAndSelfTo<WindowsProvider>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<MapSettings>().FromResource("MapSettings");
			Container.BindInterfacesAndSelfTo<MapProvider>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle().NonLazy();

			ResolveAll();
		}

		private void ResolveAll() {
			Container.Resolve<IMapSettings>();
			Container.Resolve<IWindowsProvider>();
			Container.Resolve<IMapProvider>();
			Container.Resolve<IPlayerProvider>();
		}
	}
}