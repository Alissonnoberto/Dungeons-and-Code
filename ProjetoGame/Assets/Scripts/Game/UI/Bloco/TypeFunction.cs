using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class TypeFunction : MonoBehaviour {

	public enum Type {nothing, moveUp, moveDown, moveLeft, moveRight, push, funcFor, funcForEnd};
	[SerializeField]
	public Type type = Type.nothing;

	[Header("Textos")]
	public Text textPanel, textCode;
	public GameObject workMe;

	[Header("Função For")]
	public GameObject funcFor;
	public GameObject dropDownFor;
	[SerializeField]
	public int contFor;

	// Use this for initialization
	void Start () {
		updateTextPanel ();
		updateTextCode ();
	}

	void Update(){
		if (type == Type.funcFor) {
			if (dropDownFor != null) {
				contFor = dropDownFor.GetComponent<Dropdown> ().value + 1;
			}
		}
	}

	void updateTextPanel(){
		switch (type) {
		case Type.moveUp:
			textPanel.text = "MoveUp()";
			break;
		case Type.moveDown:
			textPanel.text = "MoveDown()";
			break;
		case Type.moveLeft:
			textPanel.text = "MoveLeft()";
			break;
		case Type.moveRight:
			textPanel.text = "MoveRight()";
			break;
		case Type.push:
			textPanel.text = "Push()";
			break;
		case Type.funcFor:
			textPanel.text = "For()";
			break;
		case Type.funcForEnd:
			textPanel.text = "Push()";
			break;
		}
	}

	void updateTextCode(){
		switch (type) {
		case Type.moveUp:
			textCode.text = " player.MoveUp();";
			break;
		case Type.moveDown:
			textCode.text = " player.MoveDown();";
			break;
		case Type.moveLeft:
			textCode.text = " player.MoveLeft();";
			break;
		case Type.moveRight:
			textCode.text = " player.MoveRight();";
			break;
		case Type.push:
			textCode.text = " player.Push()";
			break;
		case Type.funcFor:
			textCode.text = " for( i = 0 ; i <        ; i++ ){";
			break;
		case Type.funcForEnd:
			dropDownFor.SetActive (false);
			textCode.text = " }";
			break;
		}
	}

	public void onPanel(){
		GetComponent<Image> ().enabled = false;
		textCode.gameObject.SetActive (true);
		textPanel.gameObject.SetActive (false);

		if (type == Type.funcFor) {
			dropDownFor.SetActive (true);
		}
	}

	public void offPanel(){
		GetComponent<Image> ().enabled = true;
		textCode.gameObject.SetActive (false);
		textPanel.gameObject.SetActive (true);

		if (type == Type.funcFor) {
			dropDownFor.SetActive (false);
		}
	}

	public void OnWorkMe(){
		workMe.SetActive (true);
	}

	public void OffWorkMe(){
		workMe.SetActive (false);
	}
}
