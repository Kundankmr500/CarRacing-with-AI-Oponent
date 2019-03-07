using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Vehicles.Car
{

	public class GameController : MonoBehaviour {

        public GameObject BackgroundMusic;
        public Text SpeedText;
		public static GameController Instance;
		public GameObject PlayerCar;
		public List<GameObject> AiCars;
		public GameObject GoText;
		public float targetTime;
		public Material m_material;
		int timervalue;
		bool isGameStart;
        int currentSpeed;
        AudioSource backgroundAudio;

        void Awake()
		{
			Instance = this;
            targetTime = 5.0f;
            backgroundAudio = BackgroundMusic.GetComponent<AudioSource>();
        }


		// Use this for initialization
		void Start (){
			m_material.color = Color.red;
			isGameStart = false;
			StopPlayerInputs ();
            BackgroundMusic.SetActive(false);
            backgroundAudio.volume = 1;
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

        // Decrease background audio volume
        public IEnumerator DecreaseMusicVolume()
        {
            yield return new WaitForSeconds(.5f);
            backgroundAudio.volume -= .15f;
            if(backgroundAudio.volume > 0)
                StartCoroutine(DecreaseMusicVolume());
        }

		
		// Update is called once per frame
		void Update () {
            
            if(targetTime > 0)
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

        private void FixedUpdate()
        {
            currentSpeed = (int)PlayerCar.GetComponent<CarController>().CurrentSpeed;
            SpeedText.text = "MPH: " + currentSpeed;
            //Debug.Log("current speed " + currentSpeed);
        }

        // Game Start lookup
        void GameStart()
		{
			for (int i = 0; i < AiCars.Count; i++) {
				AiCars[i].GetComponent<CarAIControl> ().enabled = true;
                AiCars[i].GetComponent<CarController>().enabled = true;
            }
			PlayerCar.GetComponent<CarController> ().enabled = true;
			PlayerCar.GetComponent<CarUserControl> ().enabled = true;
            BackgroundMusic.SetActive(true);
        }
			

	}
}
