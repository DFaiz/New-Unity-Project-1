//Unity course Summer 2015 - David Faizulaev
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slider : MonoBehaviour {

	string sliderTextString = "0";
	public Text sliderText; // public is needed to ensure it's available to be assigned in the inspector.
	
	public void textUpdate (float textUpdateNumber)
	{
		sliderTextString = textUpdateNumber.ToString();
		sliderText.text = sliderTextString;
	}
}
