using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour 
{
	public static bool playerDead;
	public static bool paused;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GameObject hazard;
	public GUISkin pauseSkin;

	public Vector3 topSpawnValues;
	public Vector3 rightSpawnValues;
	public Vector3 leftSpawnValues;
	public Vector3 bottomSpawnValues;
	
	private float timeSurvived;
	private int timeSec;
	private int timeMin;
	private int timeOfDeathMin;
	private int timeOfDeathSec;
	private int currentWave;

	void Start ()
	{
		StartCoroutine (spawnEnemyStraight (hazard));
	}

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

	IEnumerator spawnEnemyStraight (GameObject enemy)
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject enemyInstance;
				int whereSpawn = Random.Range (1, 5);
				if (whereSpawn == 1)		// spawns top
				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-topSpawnValues.x, topSpawnValues.x), topSpawnValues.y, topSpawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					enemyInstance = Instantiate (enemy, spawnPosition, spawnRotation) as GameObject;
					enemyInstance.rigidbody.AddForce(Vector3.back * 1000);

				}
				else if (whereSpawn == 2)		// spawns right
				{
					Vector3 spawnPosition = new Vector3 (rightSpawnValues.x, rightSpawnValues.y, Random.Range (-rightSpawnValues.z, rightSpawnValues.z));
					Quaternion spawnRotation = Quaternion.identity;
					enemyInstance = Instantiate (enemy, spawnPosition, spawnRotation) as GameObject;
					enemyInstance.rigidbody.AddForce(Vector3.left * 1000);
				}
				else if (whereSpawn == 3)		// spawns left
				{
					Vector3 spawnPosition = new Vector3 (leftSpawnValues.x, leftSpawnValues.y, Random.Range (-leftSpawnValues.z, leftSpawnValues.z));
					Quaternion spawnRotation = Quaternion.identity;
					enemyInstance = Instantiate (enemy, spawnPosition, spawnRotation) as GameObject;
					enemyInstance.rigidbody.AddForce(Vector3.right * 1000);
				}
				else if (whereSpawn == 4)		// spawns bottom
				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-bottomSpawnValues.x, bottomSpawnValues.x), bottomSpawnValues.y, bottomSpawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					enemyInstance = Instantiate (enemy, spawnPosition, spawnRotation) as GameObject;
					enemyInstance.rigidbody.AddForce(Vector3.forward * 1000);
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			currentWave++;
			hazardCount += 5;
			spawnWait -= 0.1f;
			if (spawnWait == 0.1f)
			{
				spawnWait = 0.1f;
			}
		}

	}
}
