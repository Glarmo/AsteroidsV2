using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour 
{
	public GameObject enemyBulletObject;
	public GameObject explosionEffect;

	GameObject playerShip;
	int startWait = 1;
	int bulletWait = 2;

	void Start()
	{
		playerShip = GameObject.Find ("Player");
		StartCoroutine (EnemyShoot(enemyBulletObject));
	}
	
	void Update () 
	{
		// rotates the ship to look at player
		transform.LookAt (playerShip.transform);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary")
		{
			Destroy(gameObject);
		}
		if (other.tag == "Player")
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
			Instantiate (explosionEffect, transform.position, transform.rotation);
		}
	}

	IEnumerator EnemyShoot (GameObject projectile)
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Instantiate (projectile, transform.position, transform.rotation);
			yield return new WaitForSeconds (bulletWait);
		}
	}
}
