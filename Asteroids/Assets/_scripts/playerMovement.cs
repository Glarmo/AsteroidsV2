using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
	public static bool redShip;
	public static bool yellowShip;
	public static bool blueShip;
	public static bool whiteShip = true;

	public static float xSetValue;
	public static float ySetValue;
	
	Vector3 dir = Vector3.zero;
	int rotationSpeed = 100;
	int speed = 2;
	
	void Update () 
	{
		if (!GUIScript.paused)
		{
			// moves the ship
			transform.Translate((Input.acceleration.x - xSetValue) * speed, 0, (Input.acceleration.y - ySetValue) * speed, Space.World);

			// rotates the ship
			dir.x = -Input.acceleration.y + ySetValue;
			dir.z = Input.acceleration.x - xSetValue;

			if (dir != Vector3.zero) 
			{
				transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),Time.deltaTime * rotationSpeed);
			}
		}

		// limits the ship to sceen space
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp01 (pos.x);
		pos.y = Mathf.Clamp01 (pos.y);
		transform.position = Camera.main.ViewportToWorldPoint(pos);
		Vector3 yPos = transform.position;
		yPos.y = 0;
		transform.position = yPos;
	}

	public void changeShipTexture (Texture texture)
	{
		renderer.material.mainTexture = texture;
	}
}
