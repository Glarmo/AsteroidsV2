using UnityEngine;
using System.Collections;

public class bullets : MonoBehaviour 
{
	void Update () 
	{
		// moves the bullet forward
		rigidbody.AddForce(transform.forward * 500);
	}

	void OnTriggerEnter(Collider other) 
	{
		print ("hit" + other);
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
