namespace App.Providers.Map.Cells {
	public interface ICell {
		int Cost { get; }
		bool IsBlock { get; }
	}
}
