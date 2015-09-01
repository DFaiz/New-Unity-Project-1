using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	//this class job is to rander ememy's ships location on map
	public  int[,] enemyShips;

	void Start(){

		enemyShips = new int[10,10];

		enemyShips [0,0] = 1;
		enemyShips [1,0] = 1;
		enemyShips [2,0] = 1;
	}

	int [,] getRandomLocation ()
	//void getRandomLocation ()
	{
		int[,] loc = new int[1,1];
		loc[0,0] = Random.Range (0, 9);
		loc[1,1] = Random.Range (0, 9);

		return loc;
	}

}
