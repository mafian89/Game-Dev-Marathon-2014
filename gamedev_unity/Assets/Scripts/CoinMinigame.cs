using UnityEngine;
using System.Collections;

public class CoinMinigame : MonoBehaviour {

	public static CoinMinigame Instance = null;

	private int[] minigame4slots;
	// Use this for initialization
	void Start () {
		minigame4slots = new int[7];
		this.setMinigame4slotFree(0,1);
		this.setMinigame4slotFree(1,2);
		this.setMinigame4slotFree(2,3);
		this.setMinigame4slotFree(3,0);
		this.setMinigame4slotFree(4,4);
		this.setMinigame4slotFree(5,5);
		this.setMinigame4slotFree(6,6);
	}

	void Awake(){
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool minigame4slotFree(int index){
		if (minigame4slots [index] == 0)
				return true;
		else
				return false;
	}

	public void setMinigame4slotFree(int index, int stone){
		minigame4slots [index] = stone;
	}

	public bool minigame4SuccesfullyFinished(){
		if (minigame4slots [0] == 4 &&
						minigame4slots [1] == 5 &&
						minigame4slots [2] == 6 &&
						minigame4slots [4] == 1 &&
						minigame4slots [5] == 2 &&
						minigame4slots [6] == 3)
						return true;
				else
						return false;
	}
	public bool minigame4Lost(){
		if (this.minigame4SuccesfullyFinished()) {
			return false;
		}
		for (int wantedStone=1; wantedStone<=6; wantedStone++) {
			for(int i=0;i<7;i++){
				if(minigame4slots[i]==wantedStone){
					if(wantedStone<=3){// yellow
						if(i<=5 && minigame4slots[i+1]==0){
							return false;
						}else if(i<=4 && minigame4slots[i+2]==0){
							return false;
						}
					}
					if(wantedStone>3){// green
						if(i>=1 && minigame4slots[i-1]==0){
							return false;
						}else if(i>=2 && minigame4slots[i-2]==0){
							return false;
						}
					}
				}
			}
		}
		return true;
	}

	public void unloadScene ()
	{
		Destroy (this);
	}
}
