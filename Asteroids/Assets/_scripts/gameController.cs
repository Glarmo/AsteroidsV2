using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 topSpawnValues;
	public Vector3 bottomSpawnValues;
	
	void Start ()
	{
		spawnAsteroids (topSpawnValues, bottomSpawnValues);
	}

	void spawnAsteroids (Vector3 spawnValues, Vector3 direction)
	{
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnPosition, spawnRotation);
	}
}
