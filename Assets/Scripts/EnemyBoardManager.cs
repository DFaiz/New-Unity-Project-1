using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBoardManager : MonoBehaviour {

	public EnemyAI enemyAI;
	private BattleShip bs;
	private Button[] all_buttons;
	private int ship_Size;

	void Start ()
	{
		Debug.Log ("start in ebm");
		ship_Size = 4;
		bs = new BattleShip ();
		bs.Init_Ship (ship_Size);
		place_Battleship ();
		Debug.Log ("done start in ebm");
	}

	private void place_Battleship ()
	{
		Vector2 vc;
		int static_y_value;
		int static_x_value;

		int i=0;

		static_y_value = Random.Range (0, 10);
		static_x_value = Random.Range (0, 10);

		Debug.Log ("creating AI's ship");

		//placing ship with 4 squars
		while (i<ship_Size)
		{
			all_buttons = this.GetComponentsInChildren<Button> ();

			//generating location for ship

			if (static_y_value>static_x_value)
			{
				vc = new Vector2 (static_x_value, Random.Range (0, 10));}
			else
			{
				vc = new Vector2 (Random.Range (0, 10), static_y_value);
			}

			if (bs.Set_Loc (vc)) 
			{
				//location ok - increase counter
				i++;
			}
		}
	}
}
