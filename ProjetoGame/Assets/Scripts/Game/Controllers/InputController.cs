using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public List<TypeFunction> inputList;

	void Update () {
		updateInputList ();
	}

	void updateInputList(){
		inputList.Clear();
		if (transform.childCount != 0) {
			for (int x = 0; x < transform.childCount; x++) {
				if (transform.GetChild (x).GetComponent<TypeFunction> () != null) {
					inputList.Add(transform.GetChild(x).GetComponent<TypeFunction>());

				}
			}
		}
	}
	public bool canStart(){
		//Verificação se o for esta correto
		int funcStart = 0;
		int funcEnd = 0;
		foreach (TypeFunction aux in inputList) {
			if (aux.type == TypeFunction.Type.funcFor) {
				if (funcStart == funcEnd) {
					funcStart++;
				} else {
					return false;
				}
			} else if(aux.type == TypeFunction.Type.funcForEnd){
				funcEnd++;
			}
		}
		if (funcStart == funcEnd) {
			return true;
		} else {
			return false;
		}
	}
}
