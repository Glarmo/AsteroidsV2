using UnityEngine;
using System.Collections;

public class playerShipShooting : playerMovement
{
	public GameObject bullet;

	void Update () 
	{
		// shoots laser
		if (Input.GetMouseButtonDown(0))
		{
			if (!GUIScript.paused)
			{
				Vector3 playerPos = transform.position;
				Vector3 playerRotation = transform.rotation.eulerAngles;
				playerRotation = new Vector3 (playerRotation.x, playerRotation.y + 90, playerRotation.z);
				Instantiate(bullet, playerPos, Quaternion.Euler(playerRotation));
			}
		}
	}

	
	void OnTriggerEnter(Collider other) 
	{
		// destroys ship if it hits a hazard
		if (other.tag == "Hazard")
		{
			Destroy(gameObject);
		}
	}
}
