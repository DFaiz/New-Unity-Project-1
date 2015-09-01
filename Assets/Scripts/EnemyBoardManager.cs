using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBoardManager : MonoBehaviour {

	public EnemyAI enemyAI;

	public void OnButtonPressed(Button btn){
		Vector2 btnPos = btn.GetComponent<ButtonInfo> ().position;
		if (enemyAI.enemyShips [(int)btnPos.x, (int)btnPos.y] == 1) {

			btn.image.color = new Color (Color.green.r,Color.green.g,Color.green.b,1f);
		} else {
			btn.image.color = new Color (Color.red.r,Color.red.g,Color.red.b,1f);
		}

	}
}
