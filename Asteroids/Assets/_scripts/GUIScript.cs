using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour 
{
	public static bool playerDead;
	public static bool paused;
	public static int currentWave;

	public playerMovement ship;

	public GUISkin pauseSkin;
	public GUISkin whiteButton;
	public GUISkin redButton;
	public GUISkin greenButton;
	public GUISkin yellowButton;
	public GUISkin blueButton;

	public Texture whiteShip;
	public Texture redShip;
	public Texture greenShip;
	public Texture yellowShip;
	public Texture blueShip;

	private float timeSurvived;
	private int timeSec;
	private int timeMin;
	private int timeOfDeathMin;
	private int timeOfDeathSec;

	void Update ()
	{
		if (GameObject.Find("Player") == null)
		{
			playerDead = true;
		}

		if (!playerDead)
		{
			timeSurvived += Time.deltaTime;
			timeSec = (int)timeSurvived;
			
			if (timeSec > 60)
			{
				timeMin++;
				timeSec = 0;
			}
		}
	}

	void OnGUI ()
	{
		// displays time + wave counter
		GUI.Label (new Rect (20, 20, 30, 20), "" + timeMin + ":" + timeSec);
		GUI.Label (new Rect (20, 40, 100, 20), "WAVE: " + currentWave);
		
		// displays retry + how long player survived
		if (playerDead == true)
		{
			timeOfDeathMin = timeMin;
			timeOfDeathSec = timeSec;
			GUI.Label (new Rect (Screen.width/2 - 100, Screen.height/2 - 40, 180, 20), "YOU SURVIVED FOR: " + timeOfDeathMin + ":" + timeOfDeathSec);
			if (GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 - 10, 100, 50), "RETRY"))
			{
				Application.LoadLevel ("level1");
				playerDead = false;
			}
		}

		GUI.skin = whiteButton;
		if (GUI.Button (new Rect (Screen.width - 50, 0, 50, Screen.height / 5), ""))
		{
			ship.changeShipTexture (whiteShip);
			playerMovement.whiteShip = true;
			playerMovement.redShip = false;
			playerMovement.greenShip = false;
			playerMovement.yellowShip = false;
			playerMovement.blueShip = false;
		}
		GUI.skin = redButton;
		if (GUI.Button (new Rect (Screen.width - 50, Screen.height/5, 50, Screen.height / 5), ""))
		{
			ship.changeShipTexture (redShip);
			playerMovement.whiteShip = false;
			playerMovement.redShip = true;
			playerMovement.greenShip = false;
			playerMovement.yellowShip = false;
			playerMovement.blueShip = false;
		}
		GUI.skin = greenButton;
		if (GUI.Button (new Rect (Screen.width - 50, Screen.height/5 * 2, 50, Screen.height / 5), ""))
		{
			ship.changeShipTexture (greenShip);
			playerMovement.whiteShip = false;
			playerMovement.redShip = false;
			playerMovement.greenShip = true;
			playerMovement.yellowShip = false;
			playerMovement.blueShip = false;
		}
		GUI.skin = yellowButton;
		if (GUI.Button (new Rect (Screen.width - 50, Screen.height/5 * 3, 50, Screen.height / 5), ""))
		{
			ship.changeShipTexture (yellowShip);
			playerMovement.whiteShip = false;
			playerMovement.redShip = false;
			playerMovement.greenShip = false;
			playerMovement.yellowShip = true;
			playerMovement.blueShip = false;
		}
		GUI.skin = blueButton;
		if (GUI.Button (new Rect (Screen.width - 50, Screen.height/5 * 4, 50, Screen.height / 5), ""))
		{
			ship.changeShipTexture (blueShip);
			playerMovement.whiteShip = false;
			playerMovement.redShip = false;
			playerMovement.greenShip = false;
			playerMovement.yellowShip = false;
			playerMovement.blueShip = true;
		}


		// displays pause button
		GUI.skin = pauseSkin;
		paused = GUI.Toggle (new Rect (10, Screen.height - 50, 40, 40), paused, "");
		if (paused == true)
		{
			if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}
			else
			{
				GUI.Label (new Rect (Screen.width/2 - 50, Screen.height/2 - 10, 100, 50), "PAUSED");
				Time.timeScale = 0;
			}
		}
	}	
}
