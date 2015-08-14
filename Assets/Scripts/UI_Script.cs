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
	
    }
 
    public void SinglePlayerPress() //This function will be used on our Singleplayer button
    {
		Debug.Log ("SinglePlayerPress");

    }
 
	public void MultiPlayerPress() //This function will be used on our Multiplayer button
	{
		Debug.Log ("MultiPlayerPress");
		MainPanel.SetActive (false);
		MultiPanel.SetActive (true);
		
	}

	public void StudentInfoPress() //This function will be used on our Student Info button
	{
		Debug.Log ("StudentInfoPress");
		MainPanel.SetActive (false);
		InfoPanel.SetActive (true);


	}

	public void BackPress(GameObject backFromPanel) //This function will be used on our Back button
	{
		Debug.Log ("BackPress");
		backFromPanel.SetActive (false);
		MainPanel.SetActive (true);
	}

	public void OptionsPress() //This function will be used on our Options Info button
	{
		Debug.Log ("OptionsPress");
		MainPanel.SetActive (false);
		OptionsPanel.SetActive (true);

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