using App.Providers.Maps.Settings;

namespace App.Providers.Maps.Factorys {
	public class CellFactory :ICellFactory {

		private IMapSettings _settings;

		public CellFactory(IMapSettings settings) {
			_settings = settings;
		}

	}
}
