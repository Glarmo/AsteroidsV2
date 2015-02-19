using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour 
{
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GameObject hazard;
	public GameObject enemyShip;

	public Vector3 topSpawnValues;
	public Vector3 rightSpawnValues;
	public Vector3 leftSpawnValues;
	public Vector3 bottomSpawnValues;
	
	void Start ()
	{
		// initialises values for when player replays
		hazardCount = 10;
		spawnWait = 1;
		if (gameModeSelectGUI.level == "level1" || gameModeSelectGUI.level == "level2")
		{
			StartCoroutine (spawnOneEnemyTypeStraight (hazard));
		}
		if (gameModeSelectGUI.level == "level3")
		{
			StartCoroutine (spawnMultipleEnemyTypesStraight (hazard, enemyShip));
		}
	}	

	IEnumerator spawnOneEnemyTypeStraight (GameObject enemy)
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
			if (GUIScript.playerDead != true)
			{	
				GUIScript.currentWave++;
				hazardCount += 5;
				spawnWait -= 0.1f;
				if (spawnWait == 0.3f)
				{
					spawnWait = 0.3f;
				}
			}
		}

	}

	IEnumerator spawnMultipleEnemyTypesStraight (GameObject enemy1, GameObject enemy2)
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject enemySpawned = enemy1;
				int enemyTypeRoll = Random.Range (1,3);

				if (enemyTypeRoll == 1)
				{
					enemySpawned = enemy1;
				}
				if (enemyTypeRoll == 2)
				{
					enemySpawned = enemy2;
				}

				GameObject enemyInstance;
				int whereSpawn = Random.Range (1, 5);
				if (whereSpawn == 1)		// spawns top
				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-topSpawnValues.x, topSpawnValues.x), topSpawnValues.y, topSpawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					enemyInstance = Instantiate (enemySpawned, spawnPosition, spawnRotation) as GameObject;
					enemyInstance.rigidbody.AddForce(Vector3.back * 1000);
					
				}
				else if (whereSpawn == 2)		// spawns right
				{
					Vector3 spawnPosition = new Vector3 (rightSpawnValues.x, rightSpawnValues.y, Random.Range (-rightSpawnValues.z, rightSpawnValues.z));
					Quaternion spawnRotation = Quaternion.identity;
					enemyInstance = Instantiate (enemySpawned, spawnPosition, spawnRotation) as GameObject;
					enemyInstance.rigidbody.AddForce(Vector3.left * 1000);
				}
				else if (whereSpawn == 3)		// spawns left
				{
					Vector3 spawnPosition = new Vector3 (leftSpawnValues.x, leftSpawnValues.y, Random.Range (-leftSpawnValues.z, leftSpawnValues.z));
					Quaternion spawnRotation = Quaternion.identity;
					enemyInstance = Instantiate (enemySpawned, spawnPosition, spawnRotation) as GameObject;
					enemyInstance.rigidbody.AddForce(Vector3.right * 1000);
				}
				else if (whereSpawn == 4)		// spawns bottom
				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-bottomSpawnValues.x, bottomSpawnValues.x), bottomSpawnValues.y, bottomSpawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					enemyInstance = Instantiate (enemySpawned, spawnPosition, spawnRotation) as GameObject;
					enemyInstance.rigidbody.AddForce(Vector3.forward * 1000);
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (GUIScript.playerDead != true)
			{	
				GUIScript.currentWave++;
				hazardCount += 5;
				spawnWait -= 0.1f;
				if (spawnWait == 0.3f)
				{
					spawnWait = 0.3f;
				}
			}
		}
	}

}
