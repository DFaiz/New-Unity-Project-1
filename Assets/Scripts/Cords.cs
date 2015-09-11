using UnityEngine;
using System.Collections;

public class Cords : MonoBehaviour
{
	private bool hitmiss;//true - hit, false - no hit
	private Vector2 Loc;

	public Cords (Vector2 v)
	{
		hitmiss = false;
		Loc = v;
	}

	public Vector2 GetCordLoc ()
	{
		return Loc;
	}

	public bool GetState ()
	{
		return hitmiss;
	}

	public void Register_Hit()
	{
		hitmiss = true;
	}

}
