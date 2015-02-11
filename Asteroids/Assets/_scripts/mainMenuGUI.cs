using UnityEngine;
using System.Collections;

public class mainMenuGUI : MonoBehaviour 
{
	public GUISkin title;

	void OnGUI ()
	{
		GUI.skin = title;
		GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 100), "ASTEROIDS");
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2, 200, 100), "PLAY"))
		{
			Application.LoadLevel ("gameModeSelect");
		}
	}
}
