using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;


public class CheckForRaceFinish : MonoBehaviour {


	public Text RankText;
	public GameObject FinishUI;
    public GameObject GameFinishFireworks;

    int count = 0;


    private void Awake()
    {
        GameFinishFireworks.SetActive(false);
    }

    /// Raises the trigger enter event.
    private void OnTriggerEnter(Collider other)
	{
//		Debug.Log (other.name);
		if (other.name == "CarWaypointBased" || other.name == "Car") {
			count++;
            if (other.name == "CarWaypointBased")
            {
                other.gameObject.GetComponent<CarController>().enabled = false;
                other.gameObject.GetComponent<CarAIControl>().enabled = false;
            }
            
            if (other.name == "Car") {
                GameFinishFireworks.SetActive(true);
				FinishGame ();
			}
		}
	}

    // Game Start lookup
    void FinishGame()
	{
        StartCoroutine(GameController.Instance.DecreaseMusicVolume());
        FinishUI.SetActive(true);
		GameController.Instance.StopPlayerInputs ();
		RankText.text = "**** Your Rank is "+ count +" ****";
		StartCoroutine (GoToFirstScene());
	}


	/// Goes to first scene.
	IEnumerator GoToFirstScene()
	{
		yield return new WaitForSeconds (4);
		SceneManager.LoadScene(0);
	}


	/// Goes to gamet scene.
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

