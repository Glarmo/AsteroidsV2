using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour 
{
	GameObject playerShip;
	public GameObject explosionEffect;

	void Start () 
	{
		// finds player and then rotates the bullet to face it
		playerShip = GameObject.Find ("Player");
		transform.LookAt (playerShip.transform);
	}

	void Update () 
	{
		// moves the bullet forward
		rigidbody.AddForce(transform.forward * 50);
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
}
