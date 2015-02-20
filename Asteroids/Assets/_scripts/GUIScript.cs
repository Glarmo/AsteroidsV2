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
	public GUISkin yellowButton;
	public GUISkin blueButton;
	public GUISkin retryButton;

	public Texture whiteShip;
	public Texture redShip;
	public Texture yellowShip;
	public Texture blueShip;
	
	private int waveSurvived;

	void Update ()
	{
		if (GameObject.Find("Player") == null)
		{
			playerDead = true;
			playerMovement.whiteShip = true;
			playerMovement.redShip = true;
			playerMovement.yellowShip = false;
			playerMovement.blueShip = false;
		}
	}

	void OnGUI ()
	{
		// displays wave counter
		GUI.skin = retryButton;
		GUI.Label (new Rect (20, 20, 170, 20), "WAVE: " + currentWave);
		
		// displays retry + how long player survived
		if (playerDead == true)
		{
			waveSurvived = currentWave;
			GUI.skin = retryButton;
			storeHighscore (currentWave);
			if (gameModeSelectGUI.level == "level1")
			{
				GUI.Label (new Rect (Screen.width/2 - 200, Screen.height/2 - 180, 400, 100), "HIGHEST WAVE: " + PlayerPrefs.GetInt("shootHighScore"));
			}
			if (gameModeSelectGUI.level == "level2")
			{
				GUI.Label (new Rect (Screen.width/2 - 200, Screen.height/2 - 180, 400, 100), "HIGHEST WAVE: " + PlayerPrefs.GetInt("smashHighScore"));
			}
			if (gameModeSelectGUI.level == "level3")
			{
				GUI.Label (new Rect (Screen.width/2 - 200, Screen.height/2 - 180, 400, 100), "HIGHEST WAVE: " + PlayerPrefs.GetInt("standardHighScore"));
			}
			GUI.Label (new Rect (Screen.width/2 - 200, Screen.height/2 - 80, 400, 100), "YOU SURVIVED UNTIL WAVE: " + waveSurvived);
			if (GUI.Button (new Rect (Screen.width/2 - 100, Screen.height/2, 200, 100), "RETRY"))
			{
				Application.LoadLevel (gameModeSelectGUI.level);
				playerDead = false;
				currentWave = 0;
			}
			if (GUI.Button (new Rect (Screen.width/2 - 100, Screen.height/2 + 150, 200, 100), "QUIT"))
			{
				Application.LoadLevel ("mainMenu");
				playerDead = false;
				Time.timeScale = 1;
				playerMovement.whiteShip = true;
				playerMovement.redShip = false;
				playerMovement.yellowShip = false;
				playerMovement.blueShip = false;
			}
		}

		// displays colour change buttons if in suitable gamemode
		if (gameModeSelectGUI.level != "level3")
		{
			GUI.skin = whiteButton;
			if (GUI.Button (new Rect (Screen.width - 50, 0, 50, Screen.height / 4), ""))
			{
				ship.changeShipTexture (whiteShip);
				playerMovement.whiteShip = true;
				playerMovement.redShip = false;
				playerMovement.yellowShip = false;
				playerMovement.blueShip = false;
			}
			GUI.skin = redButton;
			if (GUI.Button (new Rect (Screen.width - 50, Screen.height / 4, 50, Screen.height / 4), ""))
			{
				ship.changeShipTexture (redShip);
				playerMovement.whiteShip = false;
				playerMovement.redShip = true;
				playerMovement.yellowShip = false;
				playerMovement.blueShip = false;
			}
			GUI.skin = yellowButton;
			if (GUI.Button (new Rect (Screen.width - 50, Screen.height / 2, 50, Screen.height / 4), ""))
			{
				ship.changeShipTexture (yellowShip);
				playerMovement.whiteShip = false;
				playerMovement.redShip = false;
				playerMovement.yellowShip = true;
				playerMovement.blueShip = false;
			}
			GUI.skin = blueButton;
			if (GUI.Button (new Rect (Screen.width - 50, Screen.height/4 * 3, 50, Screen.height / 4), ""))
			{
				ship.changeShipTexture (blueShip);
				playerMovement.whiteShip = false;
				playerMovement.redShip = false;
				playerMovement.yellowShip = false;
				playerMovement.blueShip = true;
			}
		}

		// displays pause button
		GUI.skin = pauseSkin;
		if (GUI.Button (new Rect (10, Screen.height - 50, 40, 40), ""))
		{
			if (paused == true)
			{
				paused = false;
				Time.timeScale = 1;
			}
			else
			{
				paused = true;
			}
		}
		if (paused == true)
		{
			Time.timeScale = 0;
			GUI.skin = retryButton;
			GUI.Label (new Rect (Screen.width/2 - 100, Screen.height/2 - 80, 200, 100), "PAUSED");
			if (GUI.Button (new Rect (Screen.width/2 - 100, Screen.height/2, 200, 100), "RETRY"))
			{
				Application.LoadLevel (gameModeSelectGUI.level);
				paused = false;
				Time.timeScale = 1;
				playerMovement.whiteShip = true;
				playerMovement.redShip = false;
				playerMovement.yellowShip = false;
				playerMovement.blueShip = false;
			}
			if (GUI.Button (new Rect (Screen.width/2 - 100, Screen.height/2 + 150, 200, 100), "QUIT"))
			{
				Application.LoadLevel ("mainMenu");
				paused = false;
				Time.timeScale = 1;
				playerMovement.whiteShip = true;
				playerMovement.redShip = false;
				playerMovement.yellowShip = false;
				playerMovement.blueShip = false;
			}
		}
	}

	void storeHighscore (int score)
	{
		if (gameModeSelectGUI.level == "level3")
		{
			int highScore = PlayerPrefs.GetInt ("standardHighScore", 0);
			if (score > highScore)
			{
				PlayerPrefs.SetInt ("standardHighScore", score);
				PlayerPrefs.Save();
			}
		}
		if (gameModeSelectGUI.level == "level2")
		{
			int highScore = PlayerPrefs.GetInt ("smashHighScore", 0);
			if (score > highScore)
			{
				PlayerPrefs.SetInt ("smashHighScore", score);
				PlayerPrefs.Save();
			}
		}
		if (gameModeSelectGUI.level == "level1")
		{
			int highScore = PlayerPrefs.GetInt ("shootHighScore", 0);
			if (score > highScore)
			{
				PlayerPrefs.SetInt ("shootHighScore", score);
				PlayerPrefs.Save();
			}
		}
	}
}
