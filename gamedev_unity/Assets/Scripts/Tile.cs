using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	
	private List<GameObject> neighbourTiles;

	private bool m_uncovered = false;
	private bool m_canUncover = false;

	void Awake() {
		neighbourTiles = new List<GameObject>();
	}

	// Use this for initialization
	void Start () {
		(gameObject.renderer as SpriteRenderer).color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		Color c = Color.blue;
		if (m_uncovered) {
			c = Color.red;
		} else if (m_canUncover) {
			c = Color.green;
		}
		(gameObject.renderer as SpriteRenderer).color = c;
	}

	void OnMouseDown() {
		if (Input.GetKey("mouse 0")) {
			if (!m_canUncover) return;

			Sprite s;
			if (!uncovered) {
			    s = Resources.Load<Sprite>("Sprites/pivo");
				uncovered = true;
			}
			//renderer.sprite = s;
		}
	}
	
	public bool canUncover {
		set {
			this.m_canUncover = value;
		}

		get {
			return this.m_canUncover;
		}
	}

	public bool uncovered {
		set {
			this.m_uncovered = value;
			foreach(var tile in neighbourTiles) {
				tile.GetComponent<Tile>().canUncover = true;
			}
		}

		get { return m_uncovered; }
	}

	public void addNeighbourTile(GameObject tile) {
		neighbourTiles.Add(tile);
	}
}
