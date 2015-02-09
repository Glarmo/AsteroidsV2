using UnityEngine;
using System.Collections;

public class asteroids : MonoBehaviour 
{
	private float rotateSpeed;

	public Texture skin1;
	public Texture skin2;
	public Texture skin3;
	public GameObject childAsteroid;

	void Start ()
	{
		// sets the rotate speed to random value
		rotateSpeed = Random.Range (2f, 5f);

		// selects a random skin of 3
		int skinSelect = Random.Range (1, 4);
		if (skinSelect == 1)
		{
			renderer.material.mainTexture = skin1;
		}
		else if (skinSelect == 2)
		{
			renderer.material.mainTexture = skin2;
		}
		else
		{
			renderer.material.mainTexture = skin3;
		}
	}
	void Update ()
	{
		// rotates object as long as game is not paused
		if (!gameController.paused)
		{
			transform.Rotate(0,rotateSpeed,0);
		}

		// stops object from moving in y plane
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
