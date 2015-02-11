using UnityEngine;
using System.Collections;

public class playerShip : MonoBehaviour 
{
	public GameObject bullet;
	public static bool redBullet;
	public static bool greenBullet;
	public static bool yellowBullet;
	public static bool blueBullet;
	public static bool whiteBullet = true;

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



	public void changeShipTexture (Texture texture)
	{
		renderer.material.mainTexture = texture;
	}
}
