using UnityEngine;
using System.Collections;

public class playerShipSmash : playerMovement 
{
	void Start()
	{
		gameObject.tag = "whiteBullet";
	}

	void Update ()
	{
		changeTag ();
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
