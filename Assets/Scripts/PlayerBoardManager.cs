//Unity course Summer 2015 - David Faizulaev
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Operation of the player game board.
//Allows the player to place the battleship and is used by the enemy AI in order to make a game move.
//either hiting or missing the player's battleship.

public class PlayerBoardManager : MonoBehaviour
{
	private BattleShip bs;
	private Button[] all_buttons;
	private bool first_Completion;
	private int ship_Size;
	private int hit_Counter;

	void Start()
	{
		hit_Counter = 0;
		bs = new BattleShip ();
		ship_Size = 4;

		bs.Init_Ship (ship_Size);
		first_Completion = false;
		Debug.Log ("done start in pbm");
	}

	public void OnButtonPressed(Button btn)
	{
		Vector2 btnPos = btn.GetComponent<ButtonInfo> ().position;
		Debug.Log ("vector x " + btnPos.x + "vector y " + btnPos.y);
		//checking if boat structure is not complete yet and if it's the player's turn to build ship

		if ((Turn.Pturn)&&(CheckStructure()==false))
		{
			if (bs.Set_Loc (btnPos)) {
					//location is available and ship can be placed
					btn.image.color = new Color (Color.green.r, Color.green.g, Color.green.b, 1f);
			}
		}

		//checking if boat structure is complete and transfer the turn to the AI.
		if ((first_Completion == false)&& (CheckStructure()))
	    {
				Turn.EndTurn(false,true);
				first_Completion = true;
				Debug.Log("structure complete - change turn to PC");
		}
	}

	//Accessed by EnemyAI in order to try and hit a player's battlesip.
	public void EnemyMove (Vector2 vc)
	{
		bool attck_result = bs.ifexists (vc);
		//if 'attck_result' is TRUE then the vector recieved marks a ship's location
		if (attck_result) 
		{ 
			//move successful
			//ship exits
			//ship loc marked as hit
			Debug.Log("attack success");
			all_buttons = this.GetComponentsInChildren<Button> ();
			foreach (Button b in all_buttons)
			{
				if((b.GetComponent<ButtonInfo>().position.x == vc.x)&&
			   (b.GetComponent<ButtonInfo>().position.y == vc.y))
				{
					//checking if location has been already marked as missed
					if(b.image.color.Equals(Color.black)==false)
					{
						//mark location as hit
						b.image.color = new Color (Color.red.r,Color.red.g,Color.red.b,1f);
						hit_Counter++;
						
						if(hit_Counter == ship_Size)
						{
							Turn.AIwon=true;
							Debug.Log("game over - AI won");
							Turn.RestartLevel ();}
					}
				}
			}
		}
		//'attck_result' is FALSE the vector recieved does not mark a ship's location
		else {
			//get button loc from vector and color grey - no ship
			Debug.Log("attack failed");
			all_buttons = this.GetComponentsInChildren<Button> ();
			foreach (Button b in all_buttons)
			{
				if((b.GetComponent<ButtonInfo>().position.x == vc.x)&&
				   (b.GetComponent<ButtonInfo>().position.y == vc.y))
				{
					//checking if location has been already marked as HIT or ship loc marked
					if((b.image.color.Equals(Color.red)==false)&&(b.image.color.Equals(Color.green)==false))
					{
						//mark location as missed attempt
						b.image.color = new Color (Color.black.r,Color.black.g,Color.black.b,1f);}
				}
			}
		}
	}

	public void PlayerMove ()
	{
		Debug.Log ("player's turn now");
	}
	
	private bool CheckStructure ()
	{
		return (bs.Getstructure_state ());
	}
}