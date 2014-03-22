using UnityEngine;
using System.Collections;

public class tictactoeTile : MonoBehaviour {

	private int xPos=0;
	private int yPos = 0;
	//private int content = 0;
	// Use this for initialization
	void Start () {
		if (this.name == "minigame_5_tile11") {
			xPos = 1; yPos = 1;
		}
		else if (this.name == "minigame_5_tile12") {
			xPos = 1; yPos = 2;
		}
		else if (this.name == "minigame_5_tile13") {
			xPos = 1; yPos = 3;
		}
		else if (this.name == "minigame_5_tile21") {
			xPos = 2; yPos = 1;
		}
		else if (this.name == "minigame_5_tile22") {
			xPos = 2; yPos = 2;
		}
		else if (this.name == "minigame_5_tile23") {
			xPos = 2; yPos = 3;
		}
		else if (this.name == "minigame_5_tile31") {
			xPos = 3; yPos = 1;
		}
		else if (this.name == "minigame_5_tile32") {
			xPos = 3; yPos = 2;
		}
		else if (this.name == "minigame_5_tile33") {
			xPos = 3; yPos = 3;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (Input.GetKey("mouse 0")) {	
			if(minigame5game.Instance.symbol(yPos-1,xPos-1)!=0){
				return;
			}
			if(minigame5game.Instance.frantafranta()==0){
				minigame5game.Instance.addNewSymbol(yPos-1,xPos-1,1);
			}else{
				minigame5game.Instance.addNewSymbol(yPos-1,xPos-1,2);
			}
			if(minigame5game.Instance.isPlayerWinner()){
				print("Player wins!");
			}
			if(minigame5game.Instance.tilesFull() && !minigame5game.Instance.isPlayerWinner()){
				print("Player losts!");
			}
		}
	}
}
