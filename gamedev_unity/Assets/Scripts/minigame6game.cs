using UnityEngine;
using System.Collections;

public class minigame6game : MonoBehaviour {
	public static minigame6game Instance = null;
	// Use this for initialization

	private int variant =-1;

	void Start () {

	}

	void OnGUI(){
		GUI.contentColor = Color.black;

		if (getVariant() == 0) {
			GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),
			          "<size=33>1, 4, 9, 16, 25, 36, 49, ?? </size>");
		}
		if (getVariant() == 1) {
			GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),
			          "<size=33>0, 1, 1, 2, \n 3, 5, 8, 13, \n ?? </size>");
		}
		if (getVariant() == 2) {
			GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),
			          "<size=33>2, 3, 5, 7, 11, 13, 17, ?? </size>");
		}
		if (getVariant() == 3) {
			GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),
			          "<size=33>1, 2, 6, \n 24, 120, \n 720, ?? </size>");
		}
		if (getVariant() == 4) {
			GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),
			          "<size=33>2, 4, 7, 9, 12, 14, 17, ?? </size>");
		}
		if (getVariant() == 5) {
			GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),
			           "<size=33>3, 10, 17, 24, 31, 38, ?? </size>");
		}

		//GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),"<size=33>0, 1, 1, 2, 3, 5, 8, 13, ?? </size>");
		//GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),"<size=33>2, 3, 5, 7, 11, 13, 17, ?? </size>");
		//GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),"<size=33>1, 2, 6, 24, 120, 720, ?? </size>");
		//GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),"<size=33>2, 4, 7, 9, 12, 14, 17, ?? </size>");
		//GUI.Label(new Rect(20,20,Screen.width-20,Screen.height-20),"<size=33>3, 10, 17, 24, 31, 38, ?? </size>");


	}

	void Awake(){
		Instance = this;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public int getVariant() {
		if (variant == -1) {
			System.Random rnd = new System.Random ();
			variant = rnd.Next (0, 6);
		}
		return variant;
	}
}
