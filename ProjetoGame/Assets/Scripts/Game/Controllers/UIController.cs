using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject panelLateral;
	public GameObject panelGameOver;
	public GameObject panelWin;
	public GameObject panelPause;
	public GameObject panelTutorial;

	public void LoadScene(string name){
		SceneManager.LoadScene (name);
	}

	public void PlayMoviment(){
		if (GameController.Instance.inputController.canStart ()) {
			GameController.Instance.playerController.GetInputList ();
		}
	}
		
	void Update(){
		if (panelPause.activeSelf|| panelTutorial.activeSelf) {
			Time.timeScale = 0;
		} else
			Time.timeScale = 1;
	}
}