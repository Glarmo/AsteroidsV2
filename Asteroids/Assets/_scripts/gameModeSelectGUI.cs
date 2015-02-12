using UnityEngine;
using System.Collections;

public class gameModeSelectGUI : MonoBehaviour 
{
	public GUISkin shootColouredRocks;
	public GUISkin smashColouredRocks;

	void OnGUI ()
	{
		GUI.skin = shootColouredRocks;
		if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height / 2 - 125, 500, 250), ""))
		{
			Application.LoadLevel ("level1");
		}
		GUI.skin = smashColouredRocks;
		if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height / 2 + 125, 500, 250), ""))
		{
			Application.LoadLevel ("level2");
		}
	}
}
