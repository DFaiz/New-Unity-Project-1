using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	ButtleShipsInfo[] buttleShips;
	int currentShip;
	int shipSize;
	int lastX=-1,lastY=-1;
	void Start(){
		currentShip = 0;
		buttleShips = new ButtleShipsInfo[2];
		buttleShips [0].setShip ("dave1", 3, EROTATION.HORIZONTAL);
		buttleShips[1].setShip ("dave2", 2, EROTATION.VERTICAL);


		shipSize = buttleShips [currentShip].shipSize;
	}

	public void PlayerButtonClicked(Button btn){
		Vector2 btnPos = btn.GetComponent<ButtonInfo> ().position;
		if (lastX == -1) {
			lastX = (int)btnPos.x;
			lastY = (int)btnPos.y;
		}
		if (buttleShips [currentShip].shipsRotation == EROTATION.HORIZONTAL) {
			if(btnPos.y==lastY){
				btn.image.color=new Color (Color.grey.r,Color.grey.g,Color.grey.b,1f);
			}
			else{
				return;
			}
		} else {
			if(btnPos.x==lastX){
				btn.image.color=new Color (Color.grey.r,Color.grey.g,Color.grey.b,1f);
			}else{
				return;
			}
		
		}
		shipSize--;
		if (shipSize == 0) {
			lastX=-1;
			lastY=-1;
			buttleShips[currentShip].isSelected = true;
			currentShip++;
			shipSize = buttleShips [currentShip].shipSize;


		}



	}
}
