using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	public void PlayerAnimationWalk(TypeFunction.Type type){
		switch (type) {
		case TypeFunction.Type.moveRight:
			GetComponentInChildren<Animator> ().SetBool ("MoveRight", true);
			break;
		case TypeFunction.Type.moveLeft:
			GetComponentInChildren<Animator> ().SetBool ("MoveLeft", true);
			break;
		case TypeFunction.Type.moveDown:
			GetComponentInChildren<Animator> ().SetBool ("MoveDown", true);
			break;
		case TypeFunction.Type.moveUp:
			GetComponentInChildren<Animator> ().SetBool ("MoveUp", true);
			break;
		case TypeFunction.Type.push:
			GetComponentInChildren<Animator> ().SetBool ("Push", true);
			break;
		}
		GetComponentInChildren<Animator> ().SetBool ("isMove", true);
	}

	public void PlayerAnimationIdle(){
		GetComponentInChildren<Animator> ().SetBool ("isMove", false);
		GetComponentInChildren<Animator> ().SetBool ("MoveUp", false);
		GetComponentInChildren<Animator> ().SetBool ("MoveDown", false);
		GetComponentInChildren<Animator> ().SetBool ("MoveLeft", false);
		GetComponentInChildren<Animator> ().SetBool ("MoveRight", false);
		GetComponentInChildren<Animator> ().SetBool ("Wrong", false);
		GetComponentInChildren<Animator> ().SetBool ("Push", false);
	}

	public void PlayerAnimationWrong(){
		GetComponentInChildren<Animator> ().SetBool ("Wrong", true);
	}
}
