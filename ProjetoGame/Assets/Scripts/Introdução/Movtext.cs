using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movtext : MonoBehaviour {

	public string[] Enredo;
	public Text TextBox;
	int contador = 0;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown) {
			contador++;
		}

		if (contador < Enredo.Length) {
			TextBox.text = Enredo [contador];
		} 
		else {
			SceneManager.LoadScene ("Stage1");
		}
	}
}
