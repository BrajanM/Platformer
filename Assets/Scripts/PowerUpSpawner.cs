using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{
	public GameObject[] PowerUps;
	public int difficulty;

	public float delay;
	float timeFromSpawn;
	public float[] spawnpoints;
	System.Random rand = new System.Random();

	void Start()
	{
		timeFromSpawn = Time.fixedTime;
	}

	// Update is called once per frame
	void Update()
	{
		if (GameHandler.GameSpeed == 4)
		{
			delay = 3;
		}
		if (GameHandler.GameSpeed == 2)
		{
			delay = 6;
		}
		if (timeFromSpawn >= delay)
		{
			if (rand.Next(0, 1000) <= difficulty)
			{
				Instantiate(PowerUps[rand.Next(0,PowerUps.Length)], new Vector2(transform.position.x, spawnpoints[rand.Next(0, spawnpoints.Length)]), transform.rotation);
				timeFromSpawn = 0;
			}

		}
		timeFromSpawn += Time.deltaTime;
	}
}
