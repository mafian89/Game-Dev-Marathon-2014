using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileState
{
	public readonly int row;
	public readonly int col;
	public readonly int game;

	private bool _uncovered;
	private bool _canUncover;

	private List<TileState> _neighbourTileStates;

	public TileState(int row, int column) {
		this._neighbourTileStates = new List<TileState>();
		this.row = row;
		this.col = column;
		if (Random.Range(0, 10) > 7) {
			this.game = 1;
		} else {
			this.game = 0;
		}
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

