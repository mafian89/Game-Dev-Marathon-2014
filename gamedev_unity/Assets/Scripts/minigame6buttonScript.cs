using UnityEngine;
using System.Collections;

public class minigame6buttonScript : MonoBehaviour {
	private bool bingoButton = false; 
	// Use this for initialization
	void Start () {
		if (this.name == "5e01") {
			if(minigame6game.Instance.getVariant() == 5){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
				//print(this.gameObject.transform.position.ToString);
			}
		}
		if (this.name == "0") {
			if(minigame6game.Instance.getVariant() == 5){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "100000") {
			if(minigame6game.Instance.getVariant() == 5){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "38") {
			if(minigame6game.Instance.getVariant() == 5){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "52") {
			if(minigame6game.Instance.getVariant() == 5 || minigame6game.Instance.getVariant() == 4 || minigame6game.Instance.getVariant() ==  2 || minigame6game.Instance.getVariant() == 1 || minigame6game.Instance.getVariant() == 0){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "21") {
			if(minigame6game.Instance.getVariant() == 4 || minigame6game.Instance.getVariant() == 2 || minigame6game.Instance.getVariant() == 1){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "20") {
			if(minigame6game.Instance.getVariant() == 4 || minigame6game.Instance.getVariant() == 2 || minigame6game.Instance.getVariant() == 1){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "19") {
			if(minigame6game.Instance.getVariant() == 4 || minigame6game.Instance.getVariant() == 2 || minigame6game.Instance.getVariant() == 1){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "1420") {
			if(minigame6game.Instance.getVariant() == 3){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "1460") {
			if(minigame6game.Instance.getVariant() == 3){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "5040") {
			if(minigame6game.Instance.getVariant() == 3){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "5080") {
			if(minigame6game.Instance.getVariant() == 3){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "64") {
			if(minigame6game.Instance.getVariant() == 0){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "59") {
			if(minigame6game.Instance.getVariant() == 0){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
		if (this.name == "75") {
			if(minigame6game.Instance.getVariant() == 0){
				var pos = this.gameObject.transform.position;
				pos.z = -2f;
				this.gameObject.transform.position = pos;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		bool didWin = false;
		if (Input.GetKey ("mouse 0")) {	
			if (this.name == "38") {
				if(minigame6game.Instance.getVariant() == 5){
					didWin = true;
				}
			} else if (this.name == "21") {
				if(minigame6game.Instance.getVariant() == 1){
					didWin = true;
				}
			} else if (this.name == "19") {
				if(minigame6game.Instance.getVariant() == 4 || minigame6game.Instance.getVariant() == 2){
					didWin = true;
				}
			} else if (this.name == "5040") {
				if(minigame6game.Instance.getVariant() == 3){
					didWin = true;
				}
			} else if (this.name == "64") {
				if(minigame6game.Instance.getVariant() == 0){
					didWin = true;
				}
			}

			if (!didWin) {
				Game.Instance.descreaseLife();
			}
			Game.Instance.ResumeMainGame();
		}
	}
}
