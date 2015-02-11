using UnityEngine;
using System.Collections;

public class bullets : MonoBehaviour 
{
	public static bool redBullet;
	public static bool greenBullet;
	public static bool yellowBullet;
	public static bool blueBullet;
	public static bool whiteBullet;

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
			Destroy(other.gameObject);
		}
	}
}
