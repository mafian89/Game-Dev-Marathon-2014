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
			if (_state.type == TileType.TileTypeCubicle) s = Resources.Load<Sprite>("Sprites/cubicle1");
			else s = Resources.Load<Sprite>("Sprites/hallway1");
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
