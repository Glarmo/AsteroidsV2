using UnityEngine;
using System.Collections;

public class asteroids : MonoBehaviour 
{
	public float rotateSpeed;
	public GameObject childAsteroid;
	
	void Update ()
	{
		transform.Rotate(0,rotateSpeed,0);
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Laser")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);

		}
	}
}
