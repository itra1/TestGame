using App.Providers.Maps.Common;

namespace App.Providers.Maps {
	public interface IMapProvider {
		public IMap Map { get; }
		void GenerateMap();
	}
}
