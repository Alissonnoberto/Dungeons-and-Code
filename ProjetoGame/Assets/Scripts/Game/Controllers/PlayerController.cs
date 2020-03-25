using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	public PlayerMove playerMove;
	public PlayerAnimation playerAnimation;

	public List<TypeFunction> inputList;

	void FixedUpdate () {
		
		/*/Teste Movimentação
		if (Input.GetKeyDown (KeyCode.W)) {
			playerMove.MoveUp ();
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			playerMove.MoveDown ();
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			playerMove.MoveLeft ();
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			playerMove.MoveRight ();
		}
		*/
		//sprint (playerMove.transform.forward);
	}

	public void GetInputList(){
		inputList = GameController.Instance.inputController.inputList;
		StartCoroutine (WaittoMove (0.02f));

	}

	IEnumerator WaittoMove(float seconds){
		if (GameObject.Find ("Main Camera").GetComponent<CameraController> () != null) {
			GameController.Instance.cameraController.PlayGameCamera ();
			GameController.Instance.cameraController.isRunning = true;
		}
		int forCount = 0;
		int auxForCountBack = 0;
		for (int i = 0; i < inputList.Count; i++) {
			TypeFunction aux = inputList [i];
			playerAnimation.PlayerAnimationWalk (aux.type);
//			print (aux.type.ToString ());
			switch (aux.type) {
			case TypeFunction.Type.moveUp:
				aux.OnWorkMe ();
				playerMove.MoveUp ();
				yield return new WaitWhile (() => playerMove.isMove != false);
				playerAnimation.PlayerAnimationIdle ();
				yield return new WaitForSeconds (seconds);
				break;
			case TypeFunction.Type.moveDown:
				aux.OnWorkMe ();
				playerMove.MoveDown ();
				yield return new WaitWhile (() => playerMove.isMove != false);
				playerAnimation.PlayerAnimationIdle ();
				yield return new WaitForSeconds (seconds);
				break;
			case TypeFunction.Type.moveLeft:
				aux.OnWorkMe ();
				playerMove.MoveLeft ();
				yield return new WaitWhile (() => playerMove.isMove != false);
				playerAnimation.PlayerAnimationIdle ();
				yield return new WaitForSeconds (seconds);
				break;
			case TypeFunction.Type.moveRight:
				aux.OnWorkMe ();
				playerMove.MoveRight ();
				yield return new WaitWhile (() => playerMove.isMove != false);
				playerAnimation.PlayerAnimationIdle ();
				yield return new WaitForSeconds (seconds);
				break;
			case TypeFunction.Type.push:
				aux.OnWorkMe ();
				playerMove.push ();
				yield return new WaitForSeconds (1f);
				playerAnimation.PlayerAnimationIdle ();
				break;
			case TypeFunction.Type.funcFor:
				aux.OnWorkMe ();
				forCount = aux.contFor;
				auxForCountBack = i;
				yield return new WaitForSeconds (0.2f);
				break;
			case TypeFunction.Type.funcForEnd:
				aux.OnWorkMe ();
				if (forCount > 1) {
					i = auxForCountBack;
					forCount--;
				}
				yield return new WaitForSeconds (0.2f);
				break;
			}
			if (!GameController.Instance.playerController.playerMove.canMove) {
				playerAnimation.PlayerAnimationIdle ();
				playerAnimation.PlayerAnimationWrong ();
				yield return new WaitForSeconds (1f);
				GameController.Instance.playerController.playerMove.canMove = true;
				playerAnimation.PlayerAnimationIdle ();
			}
			aux.OffWorkMe ();
		}
		GameController.Instance.PlayerWin ();
	}
}