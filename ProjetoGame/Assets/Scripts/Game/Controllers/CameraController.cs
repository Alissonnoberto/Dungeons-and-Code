using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform moveTile;
	public float cameraVelocity;
	public bool isMove = false;	
	public bool isRunning = false;
	Transform auxLowestTile = null;
	public Transform startCamera;
	public Transform pontoIni, pontoFinal;

	void FixedUpdate () {
		if (isRunning) {
			transform.position = new Vector3 (Mathf.Clamp (this.transform.position.x, pontoIni.position.x, pontoFinal.position.x), this.transform.position.y, this.transform.position.z);
			this.transform.position = new Vector3 (Mathf.MoveTowards (this.transform.position.x, GameController.Instance.playerController.playerMove.transform.position.x + 2, cameraVelocity * Time.deltaTime), this.transform.position.y, this.transform.position.z);
		}
		else
		MoveTo (moveTile);
	}

	public void MoveRight(){		
		if (this.transform.position.x < 6) {
		Transform auxLowestTile = null;
		float dist;
		float lowestDist = 60f;
		foreach (Transform auxTile in GameController.Instance.environmentController.tileMatriz.tiles) {
			if (auxTile.position.x > this.transform.position.x) {
				dist = Vector2.Distance (auxTile.position, this.transform.position);
				if (dist > 1.7f && dist < 3f) {
					lowestDist = dist;
					auxLowestTile = auxTile;
				}
			}
		}
		isMove = true;
		moveTile = auxLowestTile.transform;
		}
	}

	public void MoveLeft(){
		//this.transform.Translate (new Vector3 (-0.1f, 0, 0));
		if (this.transform.position.x > 0.5) {
			Transform auxLowestTile = null;
			float dist;
			float lowestDist = 60f;
			foreach (Transform auxTile in GameController.Instance.environmentController.tileMatriz.tiles) {
				if (auxTile.position.x < this.transform.position.x) {
					dist = Vector2.Distance (auxTile.position, this.transform.position);
					if (dist > 1.7f && dist < 3f) {
						lowestDist = dist;
						auxLowestTile = auxTile;
					}
				}
			}
			isMove = true;
			moveTile = auxLowestTile.transform;
		}
	}

	void MoveTo(Transform bloco){
		if (bloco != null) {
			this.transform.position = new Vector3(Mathf.MoveTowards(this.transform.position.x, moveTile.transform.position.x,cameraVelocity*Time.deltaTime), this.transform.position.y, this.transform.position.z);
			if (this.transform.position == bloco.transform.position) {
				isMove = false;
			}
		}
	}

	public void PlayGameCamera(){
		this.transform.position = new Vector3 (startCamera.position.x, this.transform.position.y, this.transform.position.z);
		isRunning = true;
	}
}



