using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour 
{
	public static bool playerDead;
	public static bool paused;
	public static int currentWave;

	public playerShip ship;

	public GUISkin pauseSkin;
	public GUISkin redButton;
	public GUISkin greenButton;
	public GUISkin yellowButton;
	public GUISkin blueButton;
	
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
		
		GUI.skin = redButton;
		if (GUI.Button (new Rect (10, Screen.height/2 - 115, 50, 50), ""))
		{
			ship.changeShipTexture (redShip);
			bullets.redBullet = true;
			bullets.greenBullet = false;
			bullets.yellowBullet = false;
			bullets.blueBullet = false;
		}
		GUI.skin = greenButton;
		if (GUI.Button (new Rect (10, Screen.height/2 - 55, 50, 50), ""))
		{
			ship.changeShipTexture (greenShip);
			bullets.greenBullet = true;
			bullets.redBullet = false;
			bullets.yellowBullet = false;
			bullets.blueBullet = false;
		}
		GUI.skin = yellowButton;
		if (GUI.Button (new Rect (10, Screen.height/2 + 5, 50, 50), ""))
		{
			ship.changeShipTexture (yellowShip);
			bullets.yellowBullet = true;
			bullets.redBullet = false;
			bullets.greenBullet = false;
			bullets.blueBullet = false;
		}
		GUI.skin = blueButton;
		if (GUI.Button (new Rect (10, Screen.height/2 + 65, 50, 50), ""))
		{
			ship.changeShipTexture (blueShip);
			bullets.blueBullet = true;
			bullets.redBullet = false;
			bullets.yellowBullet = false;
			bullets.greenBullet = false;
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
