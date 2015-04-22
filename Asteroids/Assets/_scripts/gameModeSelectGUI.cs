using UnityEngine;
using System.Collections;

public class gameModeSelectGUI : MonoBehaviour 
{
	public static string level;

	public GUISkin shootColouredRocks;
	public GUISkin smashColouredRocks;
	public GUISkin standardPlay;
	public GUISkin setNeutralPos;

	void OnGUI ()
	{
		GUI.skin = setNeutralPos;
		GUI.Label (new Rect (Screen.width / 2 - 450, Screen.height / 2 - 125, 250, 100), "Neutral Position");
		if (GUI.Button (new Rect (Screen.width / 2 - 300, Screen.height / 2 - 50, 100, 100), "SET"))
		{
			playerMovement.xSetValue = Input.acceleration.x;
			playerMovement.ySetValue = Input.acceleration.y;
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 450, Screen.height /2 - 50, 120, 100), "RESET"))
		{
			playerMovement.xSetValue = 0;
			playerMovement.ySetValue = 0;
		}
		GUI.skin = shootColouredRocks;
		GUI.Label (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 75, 200, 100), "Wave Reached: " + PlayerPrefs.GetInt ("shootHighScore"));
		if (GUI.Button (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 75, 300, 150), ""))
		{
			Application.LoadLevel ("level1");
			level = "level1";
		}
		GUI.skin = smashColouredRocks;
		GUI.Label (new Rect (Screen.width / 2 + 150, Screen.height / 2 + 100, 200, 100), "Wave Reached: " + PlayerPrefs.GetInt ("smashHighScore"));
		if (GUI.Button (new Rect (Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 150), ""))
		{
			Application.LoadLevel ("level2");
			level = "level2";
		}
		GUI.skin = standardPlay;
		GUI.Label (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 240, 200, 100), "Wave Reached: " + PlayerPrefs.GetInt ("standardHighScore"));
		if (GUI.Button (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 240, 300, 150), ""))
		{
			Application.LoadLevel ("level3");
			level = "level3";
		}
	}
}
