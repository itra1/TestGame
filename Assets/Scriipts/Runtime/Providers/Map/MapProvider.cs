using App.Providers.Map.Settings;

namespace App.Providers.Map {
	public class MapProvider :IMapProvider {

		private IMapSettings _settings;

		public MapProvider(IMapSettings settings) {
			_settings = settings;
		}

		public void Generate() {

		}
	}
}
