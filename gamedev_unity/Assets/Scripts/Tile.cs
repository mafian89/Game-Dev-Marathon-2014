using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public SpriteRenderer renderer;
	public BoxCollider2D collider;

	private bool beer = true;
	// Use this for initialization
	void Start () {
		beer = true;
		renderer.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown() {
		if (Input.GetKey ("mouse 0")) {
			Sprite s;
			Color c;
			if (beer) {
				s = Resources.Load<Sprite>("Sprites/heart");
				c = Color.red;
				beer = false;
			} else {
			    s = Resources.Load<Sprite>("Sprites/pivo");
				c = Color.blue;
				beer = true;

			}
			//renderer.sprite = s;
			renderer.color = c;
		}
	}
}
