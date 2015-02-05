using UnityEngine;
using System.Collections;

public class asteroids : MonoBehaviour 
{
	private float rotateSpeed;
	public GameObject childAsteroid;

	void Start ()
	{
		rotateSpeed = Random.Range (2, 5);
	}
	void Update ()
	{
		transform.Rotate(0,rotateSpeed,0);
		Vector3 Pos = transform.position;
		Pos.y = 0;
		transform.position = Pos;
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			Destroy(gameObject);
		}
	}
}
