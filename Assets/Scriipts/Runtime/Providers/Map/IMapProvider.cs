using App.Providers.Map.Cells;

namespace App.Providers.Map {
	public interface IMapProvider {

		bool ExistsOpenCell { get; }

		void GenerateMap();

		ICell GetRandomOpenCell();
	}
}
