using System.Collections.Generic;
using App.Providers.Map.Cells;
using App.Providers.Map.Settings;

namespace App.Providers.Map.Factorys {
	public class CellFactory :ICellFactory {

		private Cell _prefab;
		private List<Cell> _cells;
		private IMapSettings _settings;

		public CellFactory(IMapSettings settings) {
			_settings = settings;
		}

		//public ICell GetInstance(ICellVariation cell) {



		//}
	}
}
