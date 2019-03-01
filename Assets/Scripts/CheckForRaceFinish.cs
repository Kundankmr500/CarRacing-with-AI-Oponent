﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;


public class CheckForRaceFinish : MonoBehaviour {


	public Text RankText;
	public GameObject FinishUI;

	int count = 0;

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.name);

		if (other.name == "Car" || other.name == "CarWaypointBased") {
			count++;
		}

		if (other.name == "Car") {
			FinishGame ();
		}
	}

	/// <summary>
	/// Finishs the game.
	/// </summary>
	void FinishGame()
	{
		FinishUI.SetActive(true);
		GameController.Instance.StopGame ();
		if ( count == 1) {
			RankText.text = "**** Rank 1 ****";
		} else if (count == 2) {
			RankText.text = "**** Rank 2 ****";
		}
		StartCoroutine (GoToFirstScene());
	}

	/// <summary>
	/// Gos to first scene.
	/// </summary>
	/// <returns>The to first scene.</returns>
	IEnumerator GoToFirstScene()
	{
		yield return new WaitForSeconds (4);
		SceneManager.LoadScene(0);
	}

	/// <summary>
	/// Gos to gamet scene.
	/// </summary>
	public void GoToGametScene()
	{

		SceneManager.LoadScene(1);
	}

	/// <summary>
	/// Quits the application.
	/// </summary>
	public void QuitApplication()
	{
		Application.Quit ();
	}

}

