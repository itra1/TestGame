using App.Listeners;
using App.Providers.Game;
using App.Providers.Maps;
using App.Providers.Maps.Common;
using App.Providers.Maps.Factorys;
using App.Providers.Maps.Settings;
using App.Providers.Players;
using App.Providers.UI.Windows;
using App.Scenes;
using App.Settings;
using Zenject;

namespace App.Installers {
	public class CoreInstall :MonoInstaller {

		public override void InstallBindings() {

			Container.BindInterfacesAndSelfTo<AppSettings>().FromResource("AppSettings");

			Container.BindInterfacesAndSelfTo<SceneProvider>().FromInstance(FindAnyObjectByType<SceneProvider>());

			Container.BindInterfacesAndSelfTo<MapSettings>().FromResource("MapSettings");
			Container.BindInterfacesAndSelfTo<CellFactory>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<MapProvider>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<WindowsProvider>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<GameProvider>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<WorldClickListener>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<AppRun>().AsSingle().NonLazy();

			ResolveAll();
		}

		private void ResolveAll() {
			Container.Resolve<IAppSettings>();
			Container.Resolve<IMapSettings>();
			Container.Resolve<ICellFactory>();
			Container.Resolve<IMapProvider>();
			Container.Resolve<IPlayerProvider>();
			Container.Resolve<IWindowsProvider>();
			Container.Resolve<IGameProvider>();
			Container.Resolve<IMapGround>();
			Container.Resolve<IWorldClickListener>();
		}
	}
}