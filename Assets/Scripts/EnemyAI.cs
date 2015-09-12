//Unity course Summer 2015 - David Faizulaev
using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	//this class job is to rander ememy's ships location on map
	public  int[,] enemyShips;
	public PlayerBoardManager myboard;

	private Vector2 vc;

	void Start(){

		myboard = myboard.GetComponent<PlayerBoardManager> ();
	}

	void Update ()
	{	
		if (Turn.AIturn)
		{
			Debug.Log ("AI turn");
			MakeMove ();
			myboard.PlayerMove ();
		}
	}
	private void MakeMove ()
	{
			//Debug.Log("structure complete");
			//Debug.Log("generating random location");
		getRandomLocation ();
		myboard.EnemyMove(vc);
		Turn.EndTurn (true, false);
	}

	private void getRandomLocation ()
	{
		vc = new Vector2 (Random.Range (0, 10), Random.Range (0, 10));
		Debug.Log ("random loc " + vc.x + "   " + vc.y);
	}
}