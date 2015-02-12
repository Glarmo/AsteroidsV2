﻿using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
	public static bool redShip;
	public static bool greenShip;
	public static bool yellowShip;
	public static bool blueShip;
	public static bool whiteShip = true;
	
	Vector3 dir = Vector3.zero;
	int rotationSpeed = 10;
	int speed = 2;
	
	void Update () 
	{
		if (!GUIScript.paused)
		{
			// moves the ship
			transform.Translate(Input.acceleration.x * speed, 0, Input.acceleration.y * speed, Space.World);

			// rotates the ship
			dir.x = -Input.acceleration.y;
			dir.z = Input.acceleration.x;

			if (dir != Vector3.zero) {
				transform.rotation = Quaternion.Slerp(
					transform.rotation,
					Quaternion.LookRotation(dir),
					Time.deltaTime * rotationSpeed
					);
			}
			
			transform.Rotate(Vector3.forward * Input.acceleration.y * 5.0f);
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
