using UnityEngine;
using System.Collections;

public class asteroids : MonoBehaviour 
{
	private float rotateSpeed;
	private float size;

	public Texture whiteAsteroid;
	public Texture redAsteroid;
	public Texture greenAsteroid;
	public Texture yellowAsteroid;
	public Texture blueAsteroid;

	public GameObject childAsteroid;

	private bool whiteCollison;
	private bool redCollison;
	private bool greenCollison;
	private bool yellowCollison;
	private bool blueCollison;

	void Start ()
	{
		// sets the rotate speed to random value
		rotateSpeed = Random.Range (2f, 5f);

		size = Random.Range (1f, 10f);
		transform.localScale = new Vector3 (size, 1, size);

		// selects a random colour
		int skinSelect = Random.Range (1, 6);
		if (skinSelect == 1)
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
			renderer.material.mainTexture = greenAsteroid;
			greenCollison = true;
		}
		else if (skinSelect == 4)
		{
			renderer.material.mainTexture = yellowAsteroid;
			yellowCollison = true;
		}
		else if (skinSelect == 5)
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
				}
				else
				{
					Destroy(other.gameObject);
				}
			}
			if (redCollison == true)
			{
				if (other.tag == "redBullet")
				{
					Destroy(gameObject);
				}
				else
				{
					Destroy(other.gameObject);
				}
			}
			if (greenCollison == true)
			{
				if (other.tag == "greenBullet")
				{
					Destroy(gameObject);
				}
				else
				{
					Destroy(other.gameObject);
				}
			}
			if (yellowCollison == true)
			{
				if (other.tag == "yellowBullet")
				{
					Destroy(gameObject);
				}
				else
				{
					Destroy(other.gameObject);
				}
			}
			if (blueCollison == true)
			{
				if (other.tag == "blueBullet")
				{
					Destroy(gameObject);
				}
				else
				{
					Destroy(other.gameObject);
				}
			}
		}
	}
}
