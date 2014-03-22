using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TileType { TileTypeCubicle, TileTypeHallway };

public class TileState
{

	public readonly int row;
	public readonly int col;
	public readonly int game;
	public readonly TileType type;

	private bool _uncovered;
	private bool _canUncover;

	private List<TileState> _neighbourTileStates;

	public TileState(int row, int column) {
		this._neighbourTileStates = new List<TileState>();
		this.row = row;
		this.col = column;
		float rand = Random.value;
		if (rand < 0.8f) {
			this.game = 0;
		} else if (rand < 0.85f) {
			this.game = 1;
		} else if (rand < 0.925f) {
			this.game = 3;
		} else {
			this.game = 4;
		}

		this.type = this.game > 0 ? TileType.TileTypeCubicle : TileType.TileTypeHallway;
	}

	public void addNeighbourState(TileState neighbourState) {
		_neighbourTileStates.Add(neighbourState);
	}

	public bool isUncovered {
		get {
			return this._uncovered;
		}
		set {
			this._uncovered = value;
			if (this._uncovered) {
				foreach (var tileState in _neighbourTileStates) {
					tileState.canUncover = true;
				}
			}
		}
	}

	public bool canUncover {
		get { return this._canUncover; }
		set { this._canUncover = value; }
	}
}

