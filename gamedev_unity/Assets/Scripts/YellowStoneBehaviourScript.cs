using UnityEngine;
using System.Collections;

public class YellowStoneBehaviourScript : MonoBehaviour {

	private int stoneId = 0;
	private int mySlot = 0;

	// Use this for initialization
	void Start () {
		if (this.name == "yellowstone1") {
			stoneId = 1; mySlot = 0;
		}
		else if (this.name == "yellowstone2") {
			stoneId = 2; mySlot = 1;
		}
		else if (this.name == "yellowstone3") {
			stoneId = 3; mySlot = 2;
		}
		else if (this.name == "greenstone1") {
			stoneId = 6; mySlot = 6;
		}
		else if (this.name == "greenstone2") {
			stoneId = 5; mySlot = 5;
		}
		else if (this.name == "greenstone3") {
			stoneId = 4; mySlot = 4;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		if (Input.GetKey("mouse 0")) {			
			//print("myslot" + mySlot.ToString()); 


			if(stoneId<=3){// yellow stone
				if(mySlot<=5 &&  gameScript.Instance.minigame4slotFree(mySlot+1)){// move one down
					print("Move one down!");
					var position = this.gameObject.transform.position;
					position.Set(position.x,position.y-1.42f,position.z);
					this.gameObject.transform.position = position;
					gameScript.Instance.setMinigame4slotFree(mySlot,0);
					gameScript.Instance.setMinigame4slotFree(mySlot+1,stoneId);mySlot=mySlot+1;
					//print(this.gameObject.transform.position.y);
				}else if(mySlot<=4 &&   gameScript.Instance.minigame4slotFree(mySlot+2)){// move two down
					print("Move two down!");
					var position = this.gameObject.transform.position;
					position.Set(position.x,position.y-2f*1.42f,position.z);
					this.gameObject.transform.position = position;
					gameScript.Instance.setMinigame4slotFree(mySlot,0);
					gameScript.Instance.setMinigame4slotFree(mySlot+2,stoneId);mySlot=mySlot+2;
				}else{ // you cant move
					print("Cant move!");
				}
			}else{// green stone
				if(mySlot>=1 && gameScript.Instance.minigame4slotFree(mySlot-1)){// move one up
					print("Move one up!");
					var position = this.gameObject.transform.position;
					position.Set(position.x,position.y+1.42f,position.z);
					this.gameObject.transform.position = position;
					gameScript.Instance.setMinigame4slotFree(mySlot,0);
					gameScript.Instance.setMinigame4slotFree(mySlot-1,stoneId);mySlot=mySlot-1;
				}else if(mySlot>=2 && gameScript.Instance.minigame4slotFree(mySlot-2)){// move two up
					print("Move two up!");
					var position = this.gameObject.transform.position;
					position.Set(position.x,position.y+2f*1.42f,position.z);
					this.gameObject.transform.position = position;
					gameScript.Instance.setMinigame4slotFree(mySlot,0);
					gameScript.Instance.setMinigame4slotFree(mySlot-2,stoneId);mySlot=mySlot-2;
				}else{ // you cant move
					print("Cant move!");
				}
			} 
			print("Game win = " + gameScript.Instance.minigame4SuccesfullyFinished());
			print("Game lost = " + gameScript.Instance.minigame4Lost());
		}
	}
}
