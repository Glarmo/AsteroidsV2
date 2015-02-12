using UnityEngine;
using System.Collections;

public class playerShipSmash : playerMovement 
{
	void Update ()
	{
		changeTag ();
	}

	void OnTriggerEnter (Collider other)
	{
		 
	}

	void changeTag ()
	{
		if (playerMovement.whiteShip == true)
		{
			gameObject.tag = "whiteBullet";
		}
		else if (playerMovement.redShip == true)
		{
			gameObject.tag = "redBullet";
		}
		else if (playerMovement.greenShip == true)
		{
			gameObject.tag = "greenBullet";
		}
		else if (playerMovement.yellowShip == true)
		{
			gameObject.tag = "yellowBullet";
		}
		else if (playerMovement.blueShip == true)
		{
			gameObject.tag = "blueBullet";
		}
	}
}
