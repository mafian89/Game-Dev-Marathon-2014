using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HudManager : MonoBehaviour {

	private List<GameObject> _hearts = new List<GameObject>();
	private Sprite _emptyHeart;
	private Sprite _filledHeart;

	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	void Awake() {
		_emptyHeart = Resources.Load<Sprite>("Sprites/hearth_empty");
		_filledHeart = Resources.Load<Sprite>("Sprites/hearth_filled");

		_hearts.Add(heart1);
		_hearts.Add(heart2);
		_hearts.Add(heart3);

		int lives = Game.Instance.GetLives();
		for (int i = 0; i < 3; i++) {
			Sprite s =  _filledHeart;
			if (i > lives - 1) {
				s =  _emptyHeart;
			}
			(_hearts[i].GetComponent("SpriteRenderer") as SpriteRenderer).sprite = s;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		var style = new GUIStyle();
		style.fontSize = 30;
		GUI.Label(new Rect(78, 600, 0, 0), "0x", style);
		GUI.Label(new Rect(155, 600, 0, 0), "0x", style);
		GUI.Label(new Rect(225, 600, 0, 0), "0x", style);
	}
}
