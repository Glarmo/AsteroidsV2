using UnityEngine;
using System.Collections;

public class gameModeSelectGUI : MonoBehaviour 
{
	public GUISkin colouredRocks;

	void OnGUI ()
	{
		GUI.skin = colouredRocks;
		if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height / 2 - 125, 500, 250), ""))
		{
			Application.LoadLevel ("level1");
		}
	}
}
