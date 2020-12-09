using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	public GameObject RestartMenuPanel;
	public GameObject[] HealthPointsArray;
	public GameObject Player;

	public static bool gameOver;
	public static bool trapTrigered;
	public static bool healthGained;
	public static bool slowTimeActivated;
	public static bool immortalityActivated;
	public static float GameSpeed;

	private int healthPoints=3;

	public float slowTimeDelay;
	float timeFromSlow;
	public float immortalityDelay;
	float timeFromImmortality;

	// Start is called before the first frame update
	void Start()
    {
		RestartMenuPanel.gameObject.SetActive(false);
		gameOver = false;
		trapTrigered = false;
		healthGained = false;
		slowTimeActivated = false;
		immortalityActivated = false;
		GameSpeed = 4;

	}

    // Update is called once per frame
    void Update()
    {
		if (gameOver)
		{
			RestartMenuPanel.gameObject.SetActive(true);
		}

		if (trapTrigered)
		{
			if (!immortalityActivated)
			{
				TrapTrigered();
			}
		}
		if (healthGained)
		{
			HealthGained();
		}
		if (slowTimeActivated)
		{
			SlowTimeActivated();
		}
		if (immortalityActivated)
		{
			ImmortalityActivated();
		}

    }

	public void RestartButtonClick()
	{
		SceneManager.LoadScene("SampleScene");
	}

	public void TrapTrigered()
	{
		healthPoints--;
		if (healthPoints==2)
		{
			HealthPointsArray[2].SetActive(false);
		}
		if (healthPoints == 1)
		{
			HealthPointsArray[1].SetActive(false);
		}
		if (healthPoints == 0)
		{
			HealthPointsArray[0].SetActive(false);
			gameOver = true;
			Player.SetActive(false);
		}

		trapTrigered = false;
	}

	public void HealthGained()
	{
		if (healthPoints<3)
		{
			healthPoints++;
			if (healthPoints == 3)
			{
				HealthPointsArray[2].SetActive(true);
			}
			if (healthPoints ==2)
			{
				HealthPointsArray[1].SetActive(true);
			}
		}
		healthGained = false;
	}

	public void SlowTimeActivated()
	{
		GameSpeed = 2;
		if (timeFromSlow >= slowTimeDelay)
		{
			slowTimeActivated = false;
			GameSpeed = 4;
			timeFromSlow = 0;
		}
		timeFromSlow += Time.deltaTime;
	}

	public void ImmortalityActivated()
	{
		if (timeFromImmortality>=immortalityDelay)
		{
			immortalityActivated = false;
			timeFromImmortality = 0;
		}
		timeFromImmortality += Time.deltaTime;
	}


}
