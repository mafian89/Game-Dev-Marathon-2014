using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TileType { CubicleWhite, Hallway, CubicleGreen, CubicleYellow };

public class TileState
{

	public readonly int row;
	public readonly int col;
	public readonly int game;
	public readonly TileType type;

	public bool hasPlayed {
		get { return this._hasPlayed; }
		set { this._hasPlayed = value; }
	}

	private bool _uncovered;
	private bool _canUncover;
	private bool _isBlocked;
	private bool _hasPlayed;


	private List<TileState> _neighbourTileStates;

	private int _blockCount = 0;

	public TileState(int row, int column) {
		this._neighbourTileStates = new List<TileState>();
		this.row = row;
		this.col = column;

		float rand = Random.value;
		if (rand < 0.6f) {
			this.game = 0;
			this.type = TileType.Hallway;
		} else if (rand < 0.65f) {
			this.game = 1;
			this.type = TileType.CubicleGreen;
		} else if (rand < 0.825f) {
			this.game = 3;
			this.type = TileType.CubicleWhite;
		} else {
			this.game = 4;
			this.type = TileType.CubicleYellow;
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
					if (type == TileType.CubicleWhite || type == TileType.CubicleGreen || type == TileType.CubicleYellow) {
						tileState.increaseBlockCount();
					}
				}
			}
		}
	}

	public bool canUncover {
		get { return this._canUncover; }
		set { this._canUncover = value; }
	}

	public bool isBlocked {
		get { return _blockCount > 0; }
	}

	public void unblockNeighbours ()
	{
		foreach(var neighbour in _neighbourTileStates) {
			neighbour.descreaseBlockCount();
		}
	}

	public void descreaseBlockCount ()
	{
		if (_blockCount > 0) 
			_blockCount--;
	}

	public void increaseBlockCount()
	{
		_blockCount++;
	}
}

