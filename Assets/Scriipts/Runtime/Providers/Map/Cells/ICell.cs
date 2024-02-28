using UnityEngine;

namespace App.Providers.Map.Cells {
	public interface ICell {
		int Cost { get; }
		bool IsBlock { get; }
		object Locker { get; set; }
		bool IsLock { get; }
		Vector2Int Coordinate { get; }
		Vector3 WorldPosition { get; }
		void SetCoordinate(Vector2Int coordinate);
		bool InOneLine(ICell targetCell);
	}
}
