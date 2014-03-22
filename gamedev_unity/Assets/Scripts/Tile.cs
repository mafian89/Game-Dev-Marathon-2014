using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {

	private TileState _state = null;
	
	void Awake() {
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (_state == null) return;

		Sprite s = Resources.Load<Sprite>("Sprites/covered");

		if (_state.isUncovered) {
			if (!_state.hasPlayed) {
				if (_state.type == TileType.CubicleGreen) {
					s = Resources.Load<Sprite>("Sprites/green_cubicle_tile");
				} else if (_state.type == TileType.CubicleWhite) { 
					s = Resources.Load<Sprite>("Sprites/white_cubicle_tile");
				} else if (_state.type == TileType.Hallway) { 
					s = Resources.Load<Sprite>("Sprites/hallway");
				} else if (_state.type == TileType.CubicleYellow) {
					s = Resources.Load<Sprite>("Sprites/yellow_cubicle_tile");
				}
			} else {
				if (_state.type == TileType.CubicleGreen) {
					s = Resources.Load<Sprite>("Sprites/green_cubicle_empty_tile");
				} else if (_state.type == TileType.CubicleWhite) { 
					s = Resources.Load<Sprite>("Sprites/white_cubicle_empty_tile");
				} else if (_state.type == TileType.CubicleYellow) {
					s = Resources.Load<Sprite>("Sprites/yellow_cubicle_empty_tile");
				}
			}

		} else if (_state.isBlocked) {
			s = Resources.Load<Sprite>("Sprites/blocked");
		} else if (_state.canUncover) {
			s = Resources.Load<Sprite>("Sprites/uncoverable");
		}
		(gameObject.renderer as SpriteRenderer).sprite = s;
	}

	void OnMouseDown() {
		if (Input.GetKey("mouse 0")) {
			if (!_state.isUncovered && _state.canUncover && !_state.isBlocked) {
				_state.isUncovered = true;
			} else if (_state.isUncovered && !_state.hasPlayed) {
				if (_state.game != 0) {
					Game.Instance.StartMinigame(_state.game);
					_state.hasPlayed = true;
					_state.unblockNeighbours();
				}
			}
		}
	}

	public TileState state {
		set {
			this._state = value;
		}
		get {
			return this._state;
		}
	}
}
