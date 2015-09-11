using UnityEngine;
using System.Collections;

public class Turn : MonoBehaviour
{
	public static bool Pturn;
	public static bool AIturn;

	// Use this for initialization
	void Start ()
	{
		Pturn = true;
		AIturn = false;
	}

	public static void EndTurn (bool x,bool y)
	{
		Pturn = x;
		AIturn = y;
	}
}

