//Unity course Summer 2015 - David Faizulaev
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Operation of the AI game board.
//At initilazation the AI places the battleship and is used by the PlayerBoardManager
//in order to make a game move upon button press.
//either hiting or missing the AI's battleship.
public class EnemyBoardManager : MonoBehaviour {

	public EnemyAI enemyAI;
	private BattleShip bs;
	private Button[] all_buttons;
	private int ship_Size;
	private int hit_Counter;

	void Start ()
	{
		Debug.Log ("start in ebm");
		hit_Counter = 0;
		ship_Size = 4;
		bs = new BattleShip ();
		bs.Init_Ship (ship_Size);
		place_Battleship ();
		Debug.Log ("done start in ebm");
	}

	private void place_Battleship ()
	{
		Vector2 vc;

		int random_x_value=0;
		int random_y_value=0;

		int last_placed_x = 0;
		int last_placed_y = 0;

		int initial_y = 0;
		int initial_x = 0;

		int i=0;
		int temp_calc;

		//placing first loc of AI ship
		random_y_value = Random.Range (0, 10);
		random_x_value = Random.Range (0, 10);

		vc = new Vector2 (random_x_value, random_y_value);
		
		if (bs.Set_Loc (vc)) 
		{
			//location ok - increase counter
			initial_y = random_y_value;
			initial_x = random_x_value;
			last_placed_y = initial_y;
			last_placed_x = random_x_value;
			Debug.Log("Placed AI ship at X" + vc.x + " Y" + vc.y);
			i++;
		}

		Debug.Log ("continuing creation of AI's ship");

		//placing ship with 4 squars
		while (i<ship_Size)
		{
			//generating location for ship
			//if condition occurs, then Y axis is contant and X values will be randomly generated.
			if (initial_y>initial_x)
			{
				temp_calc = initial_x - (ship_Size - (ship_Size - i));
				do {
					random_x_value = Random.Range (temp_calc, ((initial_x+3)-(i-1)));
				} while ((random_x_value>=10)||(random_x_value<0));

				vc = new Vector2 (random_x_value, initial_y);

				if (bs.Set_Loc (vc)) 
				{
					//location ok - increase counter
					last_placed_x = random_x_value;
					Debug.Log("Placed AI ship at X" + vc.x + " Y" + vc.y);
					i++;
				}
			}
			//X axis is contant and Y values will be randomly generated.
			else
			{
				temp_calc = initial_y - (ship_Size - (ship_Size - i));
				do {
						random_y_value = Random.Range (temp_calc, ((initial_y+3)-(i-1)));
				} while ((random_y_value>=10)||(random_y_value<0));

				vc = new Vector2 (initial_x, random_y_value);

				if (bs.Set_Loc (vc)) 
				{
					//location ok - increase counter
					last_placed_y = random_y_value;
					Debug.Log("Placed AI ship at X" + vc.x + " Y" + vc.y);
					i++;
				}
			}
		}
	}

	public void OnButtonPressed(Button btn)
	{
		Debug.Log ("in OnButtonPressed ebm");

		bool attck_result;

		if (Turn.Pturn) {

			Vector2 btnPos = btn.GetComponent<ButtonInfo> ().position;

			Debug.Log ("vector x " + btnPos.x + "vector y " + btnPos.y);
			//checking if boat structure is not complete yet and if it's the player's turn to attack

			attck_result = bs.ifexists (btnPos);
			if (attck_result) { 
				//move successful
				//ship exits
				//ship loc marked as hit
				Debug.Log ("attack success");
				all_buttons = this.GetComponentsInChildren<Button> ();
				foreach (Button b in all_buttons) {
					if ((b.GetComponent<ButtonInfo> ().position.x == btnPos.x) &&
						(b.GetComponent<ButtonInfo> ().position.y == btnPos.y)) {
						//checking if location has been already marked as missed or hit
						if ((b.image.color.Equals (Color.black) == false) && (b.image.color.Equals (Color.red) == false)) {
							b.image.color = new Color (Color.red.r, Color.red.g, Color.red.b, 1f);
							hit_Counter++;

							if (hit_Counter == ship_Size) {
								Turn.Pwon = true;
								Debug.Log ("game over - player won");
								//winner code - 1 - player won
								Turn.RestartLevel (1);
							}
							Debug.Log("player's turn complete - change turn to PC");
							Turn.EndTurn (false, true);
						}
					}
				}
			} else {
				//get button loc from vector and color grey - no ship
				Debug.Log ("attack failed");
				all_buttons = this.GetComponentsInChildren<Button> ();
				foreach (Button b in all_buttons) {
					if ((b.GetComponent<ButtonInfo> ().position.x == btnPos.x) &&
						(b.GetComponent<ButtonInfo> ().position.y == btnPos.y)) {
						//checking if location has been already marked as HIT or ship loc marked
						if ((b.image.color.Equals (Color.black) == false) && (b.image.color.Equals (Color.red) == false)) {
							b.image.color = new Color (Color.black.r, Color.black.g, Color.black.b, 1f);
						}
						Debug.Log("player's turn complete - change turn to PC");
						Turn.EndTurn (false, true);
					}
				}
			}
		}
	}
}
