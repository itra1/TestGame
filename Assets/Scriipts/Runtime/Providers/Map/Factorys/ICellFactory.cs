using App.Providers.Map.Cells;
using App.Providers.Map.Settings;

namespace App.Providers.Map.Factorys {
	public interface ICellFactory {

		ICell MakeInstance(ICellVariation cell);
	}
}
