using UnityEngine;
using System.Collections;

public class minigame5game : MonoBehaviour {

	public static minigame5game Instance = null;
	private int[,] tiles;
	private int karelkarel=0;

	public GameObject mujTemplejt;
	public GameObject mujTemplejt2;

	private GameObject kriz;
	private GameObject kolo;

	// Use this for initialization
	void Start () {
		tiles = new int[3,3];
		kriz = Instantiate (mujTemplejt, new Vector3 (-1.0759f , -2.5582f , 0.5f), Quaternion.identity) as GameObject;
		kolo = Instantiate (mujTemplejt2, new Vector3 (-1.0759f+5, -2.5582f , 0.5f), Quaternion.identity) as GameObject;
		System.Random rnd = new System.Random();
		int randomNumber = rnd.Next(0, 3);
		int randX, randY, randSymbol;
		for (int i=0; i<randomNumber; i++) {
			randX=rnd.Next(0, 3);
			randY=rnd.Next(0, 3);
			randSymbol=rnd.Next(1, 3);
			this.addNewSymbol(randX,randY,randSymbol);
		}
	}

	void Awake(){
		Instance = this;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void addNewSymbol(int x, int y, int symbol){
		tiles[x,y] = symbol;
		karelkarel = (karelkarel + 1) % 2;

		var pos1 = kolo.gameObject.transform.position;
		var pos2 = kriz.gameObject.transform.position;
		kriz.gameObject.transform.position = pos1;
		kolo.gameObject.transform.position = pos2;

		if (symbol == 1) {
			var nic = Instantiate (mujTemplejt, new Vector3 (-2.6133f + x*1.48f, 3.248f - y*1.45f, 0.5f), Quaternion.identity) as GameObject;
		} else {
			var nic = Instantiate (mujTemplejt2, new Vector3 (-2.6133f + x*1.48f, 3.248f - y*1.45f, 0.5f), Quaternion.identity) as GameObject;
		}

	}

	public int symbol(int xpos, int ypos){
		return tiles[xpos,ypos];
	}

	public bool isPlayerWinner(){
		if (!tilesFull ()) {
			return false;
		}
		if (tiles [0, 0] == tiles [0, 1] && tiles [0, 1] == tiles [0, 2]) {
			return false;
		}
		if (tiles [1, 0] == tiles [1, 1] && tiles [1, 1] == tiles [1, 2]) {
			return false;
		}
		if (tiles [2, 0] == tiles [2, 1] && tiles [2, 1] == tiles [2, 2]) {
			return false;
		}
		if (tiles [0, 0] == tiles [1, 0] && tiles [1, 0] == tiles [2, 0]) {
			return false;
		}
		if (tiles [0, 1] == tiles [1, 1] && tiles [1, 1] == tiles [2, 1]) {
			return false;
		}
		if (tiles [0, 2] == tiles [1, 2] && tiles [1, 2] == tiles [2, 2]) {
			return false;
		}
		if (tiles [0, 0] == tiles [1, 1] && tiles [1, 1] == tiles [2, 2]) {
			return false;
		}
		if (tiles [2, 0] == tiles [1, 1] && tiles [1, 1] == tiles [0, 2]) {
			return false;
		}
		return true;
	}
	public bool tilesFull(){
		for(int i=0;i<3;i++){
			for(int j=0;j<3;j++){
				if(tiles[i,j]==0){
					return false;
				}
			}
		}
		return true;
	}
	public int frantafranta(){
		return karelkarel;
	}

}
