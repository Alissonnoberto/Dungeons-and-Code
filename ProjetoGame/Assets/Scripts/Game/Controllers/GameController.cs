using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private static GameController instance;
	public static GameController Instance{
		get{
			if(instance == null){
				instance = FindObjectOfType<GameController> ();
			}
			return instance;
		}
	}

	public EnvironmentController environmentController;
	public PlayerController playerController;
	public InputController inputController;
	public UIController uiController;
	public CameraController cameraController;
	public AudioController audioController;

	public GameObject finalPoint;
	public Text timerUI;
	public float time;
	bool isRunning = true;


	public void PlayerWin(){
		if (finalPoint.transform.position == Instance.playerController.playerMove.transform.position) {
			Instance.uiController.panelWin.SetActive (true);
			isRunning = false;
			Time.timeScale = 0;
			audioController.stageMusic.GetComponent<AudioSource> ().Stop ();

		} else {
			Instance.uiController.panelGameOver.SetActive (true);
			isRunning = false;
			Time.timeScale = 0;
			audioController.stageMusic.GetComponent<AudioSource> ().Stop ();
		}
	}

	void FixedUpdate(){
		if (isRunning) {
			timerUI.text = (int)time + "s Restante";
			time -= Time.deltaTime;
			if (uiController.panelWin.activeSelf) {
				isRunning = false;
			}
			if (time <= 0) {
				PlayerWin ();
				isRunning = false;
			}
		}
	}

}
