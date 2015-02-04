using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 topSpawnValues;
	public Vector3 rightSpawnValues;
	public Vector3 leftSpawnValues;
	public Vector3 bottomSpawnValues;
	
	void Start ()
	{
		spawnEnemyStraight (hazard);
	}

	void spawnEnemyStraight (GameObject enemy)
	{
		GameObject enemyInstance;
		int whereSpawn = Random.Range (1, 4);

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



	}
}
