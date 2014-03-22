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
		int rand = Random.Range(0, 3);
		switch (rand) {
		case 0:
			this.game = 0;
			break;
		
		case 1:
			this.game = 1;
			break;

		case 2:
			this.game = 3;
			break;

		case 3:
			this.game = 4;
			break;
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

