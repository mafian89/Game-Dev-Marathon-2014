using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class Game : MonoBehaviour {
	public static Game Instance = null;
	
	private List<TileState> _tileStates;

	private int _bills = 0;
	private int _kegs = 0;
	private int _lives = 3;

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
		//Application.LoadLevelAdditive("CoinMinigame");
	}

	public int increaseBills() {
		_bills++;
		return _bills;
	}

	public int descreseBills() {
		if (_bills > 0) {
			_bills--;
		}
		return _bills;
	}

	public int increaseKegs() {
		_kegs++;
		return _kegs;
	}
	
	public int descreseKegs() {
		if (_kegs > 0) {
			_kegs--;
		}
		return _kegs;
	}
	
	public int descreaseLife() {
		if (_lives > 1) {
			_lives--;
			return _lives;
		}
		GameOver();
		return _lives;
	}

	bool _isGameOver = false;

	void GameOver ()
	{
		_isGameOver = true;
	}

	void OnGUI() {
		if (_isGameOver) {
			if (GUI.Button (new Rect(10, 10, 150, 100), "New Game")) {
				_isGameOver = false;
				_lives = 3;
				_kegs = 0;
				_bills = 0;
				initGame();
			}
		}
	}
}
