using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HudManager : MonoBehaviour {

	private List<GameObject> _hearts = new List<GameObject>();

	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	void Awake() {
		_hearts.Add(heart1);
		_hearts.Add(heart2);
		_hearts.Add(heart3);

		for (int i = 0; i < Game.Instance.GetLives(); i++) {
			GameObject heart = _hearts[i];
			(heart.GetComponent("SpriteRenderer") as SpriteRenderer).enabled = true;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
