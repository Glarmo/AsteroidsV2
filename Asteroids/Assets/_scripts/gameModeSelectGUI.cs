using UnityEngine;
using System.Collections;

public class gameModeSelectGUI : MonoBehaviour 
{
	public static string level;

	public GUISkin shootColouredRocks;
	public GUISkin smashColouredRocks;
	public GUISkin standardPlay;

	void OnGUI ()
	{
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
