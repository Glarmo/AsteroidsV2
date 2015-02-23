using UnityEngine;
using System.Collections;

public class asteroids : MonoBehaviour 
{
	private float rotateSpeed;
	private float size;

	public Texture whiteAsteroid;
	public Texture redAsteroid;
	public Texture yellowAsteroid;
	public Texture blueAsteroid;

	public GameObject particleDeathEffect;

	private bool whiteCollison;
	private bool redCollison;
	private bool yellowCollison;
	private bool blueCollison;

	void Start ()
	{
		// sets the rotate speed to random value
		rotateSpeed = Random.Range (2f, 5f);

		size = Random.Range (3f, 10f);
		transform.localScale = new Vector3 (size, 1, size);

		// selects a random colour
		int skinSelect = Random.Range (1, 5);
		if (skinSelect == 1 || gameModeSelectGUI.level == "level3")
		{
			renderer.material.mainTexture = whiteAsteroid;
			whiteCollison = true;
		}
		else if (skinSelect == 2)
		{
			renderer.material.mainTexture = redAsteroid;
			redCollison = true;
		}
		else if (skinSelect == 3)
		{
			renderer.material.mainTexture = yellowAsteroid;
			yellowCollison = true;
		}
		else if (skinSelect == 4)
		{
			renderer.material.mainTexture = blueAsteroid;
			blueCollison = true;
		}
	}
	void Update ()
	{
		// rotates object as long as game is not paused
		if (!GUIScript.paused)
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
		else
		{
			if (whiteCollison == true)
			{
				if (other.tag == "whiteBullet")
				{
					Destroy(gameObject);
					Instantiate (particleDeathEffect, transform.position, transform.rotation);
				}
				else
				{
					Destroy(other.gameObject);
					Instantiate (particleDeathEffect, transform.position, transform.rotation);
				}
			}
			if (redCollison == true)
			{
				if (other.tag == "redBullet")
				{
					Destroy(gameObject);
					Instantiate (particleDeathEffect, transform.position, transform.rotation);
				}
				else
				{
					Destroy(other.gameObject);
					Instantiate (particleDeathEffect, transform.position, transform.rotation);
				}
			}
			if (yellowCollison == true)
			{
				if (other.tag == "yellowBullet")
				{
					Destroy(gameObject);
					Instantiate (particleDeathEffect, transform.position, transform.rotation);
				}
				else
				{
					Destroy(other.gameObject);
					Instantiate (particleDeathEffect, transform.position, transform.rotation);
				}
			}
			if (blueCollison == true)
			{
				if (other.tag == "blueBullet")
				{
					Destroy(gameObject);
					Instantiate (particleDeathEffect, transform.position, transform.rotation);
				}
				else
				{
					Destroy(other.gameObject);
					Instantiate (particleDeathEffect, transform.position, transform.rotation);
				}
			}
		}
	}
}
