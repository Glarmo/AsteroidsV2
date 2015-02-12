using UnityEngine;
using System.Collections;

public class bullets : playerMovement

{
	void Start ()
	{
		changeColourTag ();
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
	}

	void changeColourTag ()
	{
		if (playerMovement.whiteShip == true)
		{
			gameObject.tag = "whiteBullet";
			gameObject.renderer.material.color = Color.white;
		}
		else if (playerMovement.redShip == true)
		{
			gameObject.tag = "redBullet";
			gameObject.renderer.material.color = Color.red;
		}
		else if (playerMovement.greenShip == true)
		{
			gameObject.tag = "greenBullet";
			gameObject.renderer.material.color = Color.green;
		}
		else if (playerMovement.yellowShip == true)
		{
			gameObject.tag = "yellowBullet";
			gameObject.renderer.material.color = Color.yellow;
		}
		else if (playerMovement.blueShip == true)
		{
			gameObject.tag = "blueBullet";
			gameObject.renderer.material.color = Color.blue;
		}
	}
}
