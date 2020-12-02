using UnityEngine;
using System.Collections;

public class TrapSpawner : MonoBehaviour
{
	public GameObject platform;
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
		if (timeFromSpawn >= delay)
		{
			if (rand.Next(0,10)<=difficulty)
			{
				Instantiate(platform, new Vector2(transform.position.x, spawnpoints[rand.Next(0, spawnpoints.Length)]), transform.rotation);
				timeFromSpawn = 0;
			}
			
		}
		timeFromSpawn += Time.deltaTime;
	}
}
