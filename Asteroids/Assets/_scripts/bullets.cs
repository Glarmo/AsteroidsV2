using UnityEngine;
using System.Collections;

public class bullets : MonoBehaviour 
{
	void Start ()
	{
		if (playerShip.whiteBullet == true)
		{
			gameObject.tag = "whiteBullet";
			gameObject.renderer.material.color = Color.white;
		}
		else if (playerShip.redBullet == true)
		{
			gameObject.tag = "redBullet";
			gameObject.renderer.material.color = Color.red;
		}
		else if (playerShip.greenBullet == true)
		{
			gameObject.tag = "greenBullet";
			gameObject.renderer.material.color = Color.green;
		}
		else if (playerShip.yellowBullet == true)
		{
			gameObject.tag = "yellowBullet";
			gameObject.renderer.material.color = Color.yellow;
		}
		else if (playerShip.blueBullet == true)
		{
			gameObject.tag = "blueBullet";
			gameObject.renderer.material.color = Color.blue;
		}
	}
	void Update () 
	{
		// moves the bullet forward
		rigidbody.AddForce(transform.forward * 500);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			Destroy(gameObject);
		}

		if (other.tag == "Hazard")
		{
			Destroy(gameObject);
		}
	}
}
