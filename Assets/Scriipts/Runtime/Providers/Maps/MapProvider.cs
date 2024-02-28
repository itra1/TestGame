using App.Providers.Maps.Common;
using App.Providers.Maps.Settings;
using App.Scenes.Interfaces;

namespace App.Providers.Maps {
	public class MapProvider :IMapProvider {

		private IMapSettings _settings;
		private IMapGround _mapGround;
		private IWorldParent _worldParent;
		private IMap _map;
		public IMap Map => _map;

		public MapProvider(IMapSettings settings, IMapGround mapGround, IWorldParent worldParent) {
			_settings = settings;
			_mapGround = mapGround;
			_worldParent = worldParent;
		}

		public void GenerateMap() {
			_map = new Map(_settings, _worldParent);
			_map.MakeMap();
			_mapGround.MapGround.size = _map.MapSize;
		}
	}
}
