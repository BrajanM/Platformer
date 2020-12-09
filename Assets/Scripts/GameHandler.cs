using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	public GameObject RestartMenuPanel;

	public static bool gameOver;

	public GameObject[] HealthPointsArray;
	public GameObject Player;

	public static bool trapTrigered;
	public static bool healthGained;

	private int healthPoints=3;


    // Start is called before the first frame update
    void Start()
    {
		RestartMenuPanel.gameObject.SetActive(false);
		gameOver = false;
		trapTrigered = false;
		healthGained = false;

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
			TrapTrigered();
		}
		if (healthGained)
		{
			HealthGained();
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



}
