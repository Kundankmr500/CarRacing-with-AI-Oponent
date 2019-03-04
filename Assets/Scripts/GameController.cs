using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Vehicles.Car
{

	public class GameController : MonoBehaviour {

		public static GameController Instance;
		public GameObject PlayerCar;
		public List<GameObject> AiCars;
		public GameObject GoText;
		public float targetTime = 5.0f;
		public Material m_material;
		int timervalue;
		bool isGameStart;

		void Awake()
		{
			Instance = this;
		}


		// Use this for initialization
		void Start (){
			m_material.color = Color.red;
			isGameStart = false;
			StopPlayerInputs ();
		}

		/// <summary>
		/// Stops the game.
		/// </summary>
		public void StopPlayerInputs()
		{
			for (int i = 0; i < AiCars.Count; i++) {
				AiCars[i].GetComponent<CarAIControl> ().enabled = false;
				AiCars[i].GetComponent<CarController> ().enabled = false;
			}
			PlayerCar.GetComponent<CarController> ().enabled = false;
			PlayerCar.GetComponent<CarUserControl> ().enabled = false;

		}

		
		// Update is called once per frame
		void Update () {

			targetTime -= Time.deltaTime;
	//		Debug.Log ("targetTime " + targetTime);
			if (targetTime <= 3.0f && targetTime >= 0.0f) {
				m_material.color = Color.yellow;
			}
			if (targetTime <= 0.0f && !isGameStart) {
				m_material.color = Color.green;
				GoText.SetActive (true);
				isGameStart = true;
				GameStart ();
			}
		}

		void GameStart()
		{
			for (int i = 0; i < AiCars.Count; i++) {
				AiCars[i].GetComponent<CarAIControl> ().enabled = true;
			}
			PlayerCar.GetComponent<CarController> ().enabled = true;
			PlayerCar.GetComponent<CarUserControl> ().enabled = true;
		}
			

	}
}
