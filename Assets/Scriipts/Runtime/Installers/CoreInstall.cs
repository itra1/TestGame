using App.Providers.Map;
using App.Providers.Map.Factorys;
using App.Providers.Map.Settings;
using App.Providers.Player;
using App.Providers.UI.Windows;
using App.Scenes;
using Zenject;

namespace App.Installers {
	public class CoreInstall :MonoInstaller {

		public override void InstallBindings() {

			Container.BindInterfacesAndSelfTo<SceneProvider>().FromInstance(FindAnyObjectByType<SceneProvider>());

			Container.BindInterfacesAndSelfTo<MapSettings>().FromResource("MapSettings");
			Container.BindInterfacesAndSelfTo<CellFactory>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<MapProvider>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<WindowsProvider>().AsSingle().NonLazy();

			ResolveAll();
		}

		private void ResolveAll() {
			Container.Resolve<IMapSettings>();
			Container.Resolve<ICellFactory>();
			Container.Resolve<IMapProvider>();
			Container.Resolve<IPlayerProvider>();
			Container.Resolve<IWindowsProvider>();
		}
	}
}