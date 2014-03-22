﻿using UnityEngine;
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

		Color c = Color.white;
		//(gameObject.renderer as SpriteRenderer).sprite = Resources.Load("UncoveredTile1Prefab") as Sprite;
		if (_state.isUncovered) {
			c = Color.red;
		} else if (_state.canUncover) {
			c = Color.green;
		}
		(gameObject.renderer as SpriteRenderer).color = c;
	}

	void OnMouseDown() {
		if (Input.GetKey("mouse 0")) {
			if (!_state.isUncovered && _state.canUncover) {
				_state.isUncovered = true;
				if (_state.game != 0) {
					Game.Instance.StartMinigame(_state.game);
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
