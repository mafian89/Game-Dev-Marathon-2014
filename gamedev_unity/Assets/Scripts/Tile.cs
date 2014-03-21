using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	public SpriteRenderer renderer;
	public BoxCollider2D collider;
	
	private List<GameObject> neighbourTiles;

	private bool clicked = true;
	// Use this for initialization
	void Start () {
		clicked = true;
		renderer.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown() {
		if (Input.GetKey("mouse 0")) {
			Sprite s;
			Color c;
			if (clicked) {
				s = Resources.Load<Sprite>("Sprites/heart");
				c = Color.red;
				clicked = false;
			} else {
			    s = Resources.Load<Sprite>("Sprites/pivo");
				c = Color.blue;
				clicked = true;

			}
			//renderer.sprite = s;

			renderer.color = c;
			foreach(var tile in neighbourTiles) {
				print (tile);
			}
		}
	}


	public void addNeighbourTile(GameObject tile) {
		neighbourTiles.Add(tile);
	}
}
