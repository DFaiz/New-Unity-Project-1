using UnityEngine;
using System.Collections;

public enum EROTATION{
	HORIZONTAL,
	VERTICAL
};

public class ButtleShipsInfo : MonoBehaviour {

	string name;
	public int shipSize;
	public EROTATION shipsRotation;
	public bool isSelected;

	Vector2[] shipPositions;

	public void setShip(string shipsName,int shipSize,EROTATION shipsRotation){
		this.name = shipsName;
		this.shipSize = shipSize;
		this.shipsRotation = shipsRotation;
		this.isSelected = false;
	}
}
