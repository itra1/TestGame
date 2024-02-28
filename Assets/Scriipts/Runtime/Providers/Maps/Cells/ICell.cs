using System;
using UnityEngine;

namespace App.Providers.Maps.Cells {
	public interface ICell :IDisposable {
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
