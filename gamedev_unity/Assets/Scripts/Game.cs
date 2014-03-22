using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class Game : MonoBehaviour {
	public static Game Instance = null;

	private List<TileState> _tileStates;

	public List<TileState> TileStates {
		get {
			return this._tileStates;
		}
		set {
			this._tileStates = value;
		}
	}

	private const int ROWS = 7;
	private const int COLS = 5;

	void Awake() {
		if (!Instance) {
			Instance = this;
			initGame();
			DontDestroyOnLoad(this);
		}
	}	

	void initGame ()
	{
		Screen.SetResolution(480, 800, false);
		createTileStates();
		ResumeMainGame();
	}

	void createTileStates() {
		_tileStates = new List<TileState>();

		for (int row = 0; row < ROWS; row++) {
			for (int col = 0; col < COLS; col++) {
				_tileStates.Add(new TileState(row, col));
			}
		}

		for (int row = 0; row < ROWS; row++) {
			for (int col = 0; col < COLS; col++) {
				TileState tileState = _tileStates.Find(s => s.row == row && s.col == col);
				// top and bottom neighbours
				if (row > 0) tileState.addNeighbourState(_tileStates.Find(s => s.col == col && s.row == (row - 1)));
				if (row < (ROWS - 1)) tileState.addNeighbourState(_tileStates.Find(s => s.col == col && s.row == (row + 1)));

				// left and right neighbours
				if (col < (COLS - 1)) tileState.addNeighbourState(_tileStates.Find(s => s.col == (col + 1) && s.row == row));
				if (col > 0) tileState.addNeighbourState(_tileStates.Find(s => s.col == (col - 1) && s.row == row));
			}
		}

		// uncover top left tile
		_tileStates.Find(s => (s.row == 0 && s.col == 0)).isUncovered = true;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void StartMinigame(int i)
	{
		Application.LoadLevel(i);
	}

	public void ResumeMainGame() {
		Application.LoadLevel("MainGame");
	}
}
