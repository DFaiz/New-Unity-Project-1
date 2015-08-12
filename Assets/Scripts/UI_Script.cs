//Unity course Summer 2015 - David Faizulaev
using UnityEngine;
using UnityEngine.UI; // we need This namespace in order to access UI elements within our script
using System.Collections;
 
public class UI_Script : MonoBehaviour 
{
	//public GameObject MainPanel;
	public GameObject ParentObject;
	public GameObject MainPanel;
	public GameObject OptionsPanel;
	public GameObject MultiPanel;
	public GameObject InfoPanel;

	//Main menu elements
	public Button ButtonSINGLEPLAYER;
	public Button ButtonMULTIPLAYER;
	public Button ButtonSTUDENTINFO;
	public Button ButtonQUIT;

	//All purpose buttons (used by all canvas objects)
	public Button ButtonOPTIONS;
	public Button ButtonBACK;

	//Multiplayer play button
	public Button ButtonMPlay;

    void Start ()
    {
		Debug.Log ("load menu");

		MainPanel.SetActive (true);
		//InfoPanel.SetActive (false);
		//MultiPanel.SetActive (false);
		//OptionsPanel.SetActive (false);

		//Initialize buttons
		ButtonSINGLEPLAYER = ButtonSINGLEPLAYER.GetComponent<Button> ();
		ButtonMULTIPLAYER = ButtonMULTIPLAYER.GetComponent<Button> ();
		ButtonSTUDENTINFO = ButtonSTUDENTINFO.GetComponent<Button> ();
		ButtonOPTIONS = ButtonOPTIONS.GetComponent<Button> ();
		ButtonQUIT = ButtonQUIT.GetComponent<Button>();
		ButtonBACK = ButtonBACK.GetComponent<Button>();
		ButtonMPlay = ButtonMPlay.GetComponent<Button>();

		Debug.Log(ParentObject.transform.GetChild (0).name.ToString ());
		GameObject main = ParentObject.transform.GetChild (0).gameObject;
		ParentObject.transform.GetChild (0).gameObject.SetActive (true);

//		foreach (GameObject child in main.get) {
//			Debug.Log(child.gameObject.name.ToString());
//					child.gameObject.SetActive (true);		
//				}
//
		//Debug.Log(ParentObject.transform.GetChild (1).name.ToString ());
		//ParentObject.transform.GetChild (1).gameObject.SetActive (false);

		//Debug.Log(ParentObject.transform.GetChild (2).name.ToString ());
		//ParentObject.transform.GetChild (2).gameObject.SetActive (false);
    }
 
    public void SinglePlayerPress() //This function will be used on our Singleplayer button
    {
		Debug.Log ("SinglePlayerPress");
		//CanvasMain_Menu.enabled = false; //disable the main menu
		//StartSinglePlayerLevel ();
    }
 
	public void MultiPlayerPress() //This function will be used on our Multiplayer button
	{
		Debug.Log ("MultiPlayerPress");
		MainPanel.SetActive (false);
		MultiPanel.SetActive (true);

		//CanvasMain_Menu.enabled = false; //disable the main menu
		//CanvasMulti.enabled = true; //enable the multiplayer canvas
		//StartMultiPlayerLevel ();
	}

	public void StudentInfoPress() //This function will be used on our Student Info button
	{
		Debug.Log ("StudentInfoPress");
		MainPanel.SetActive (false);
		InfoPanel.SetActive (true);

		//CanvasMain_Menu.enabled = false; //disable the main menu
		//CanvasSInfo.enabled = true;	//enable the student info canvas
	}

	public void BackPress() //This function will be used on our Back button
	{
		Debug.Log ("BackPress");
		//CanvasMain_Menu.enabled = true; //enable the main menu
		//CanvasSInfo.enabled = false; // disable the student info canvas
		//CanvasMulti.enabled = false; // disable the multiplayer canvas
		//CanvasOptions.enabled = false; // disable the options canvas
	}

	public void OptionsPress() //This function will be used on our Options Info button
	{
		Debug.Log ("OptionsPress");
		//CanvasMain_Menu.enabled = false; //disable the main menu
		//CanvasMulti.enabled = false; // disable the multiplayer canvas
		//CanvasSInfo.enabled = false; // disable the student info canvas
		///CanvasOptions.enabled = true; //enable the options canvas
	}

    public void StartSinglePlayerLevel () //This function will be used on our Play button
    {
		//This will load our single player scene.
	 	Application.LoadLevel ("single");
    }
 
    public void StartMultiPlayerLevel () //This function will be used on our Play button
    {
		//This will load our multi player scene.
	 	Application.LoadLevel ("multi");
    }
 
    public void QuitGamePress () //This function will be used on our "Exit Game" button
    {
		Debug.Log ("ExitGamePress");
  		Application.Quit(); //This will quit our game.  
    }
}