using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public Transform moveTile;
	public float playerVelocity;
	public bool isMove = false;	
	public bool canMove = true;
	Transform auxLowestTile = null;
//	Transform auxPush = null;

	void start(){
		
	}

	void FixedUpdate () {
		MoveTo (moveTile);
	}


	public void MoveUp(){
		
		float dist;
		float lowestDist = 30f;
		foreach (Transform auxTile in GameController.Instance.environmentController.tileMatriz.tiles) {
			if (auxTile.position.y > this.transform.position.y) {
				dist = Vector2.Distance (auxTile.position, this.transform.position);
				if (dist < lowestDist) {
					lowestDist = dist;
					auxLowestTile = auxTile;
				}
			}
		}
		isMove = true;
		moveTile = auxLowestTile.transform;
	}

	public void MoveRight(){
		Transform auxLowestTile = null;
		float dist;
		float lowestDist = 30f;
		foreach (Transform auxTile in GameController.Instance.environmentController.tileMatriz.tiles) {
			if (auxTile.position.x > this.transform.position.x) {
				dist = Vector2.Distance (auxTile.position, this.transform.position);
				if (dist < lowestDist) {
					lowestDist = dist;
					auxLowestTile = auxTile;
				}
			}
		}
		isMove = true;
		moveTile = auxLowestTile.transform;
	}

	public void MoveLeft(){
		Transform auxLowestTile = null;
		float dist;
		float lowestDist = 30f;
		foreach (Transform auxTile in GameController.Instance.environmentController.tileMatriz.tiles) {
			if (auxTile.position.x < this.transform.position.x) {
				dist = Vector2.Distance (auxTile.position, this.transform.position);
				if (dist < lowestDist) {
					lowestDist = dist;
					auxLowestTile = auxTile;
				}
			}
		}
		isMove = true;
		moveTile = auxLowestTile.transform;
	}

	public void MoveDown(){
		Transform auxLowestTile = null;
		float dist;
		float lowestDist = 30f;
		foreach (Transform auxTile in GameController.Instance.environmentController.tileMatriz.tiles) {
			if (auxTile.position.y < this.transform.position.y) {
				dist = Vector2.Distance (auxTile.position, this.transform.position);
				if (dist < lowestDist) {
					lowestDist = dist;
					auxLowestTile = auxTile;
				}
			}
		}
		isMove = true;
		moveTile = auxLowestTile.transform;
	}

	public void push(){
		foreach(Transform auxObstaclo in GameController.Instance.environmentController.obstaclo){
			if (Vector2.Distance (this.transform.position, auxObstaclo.transform.position) < 1.2) {
				switch (auxObstaclo.GetComponent<ObjetoMove>().wereMove) {
				case TypeFunction.Type.moveUp:
					auxObstaclo.GetComponent<ObjetoMove>().MoveUp();
					break;
				case TypeFunction.Type.moveDown:
					auxObstaclo.GetComponent<ObjetoMove>().MoveDown();
					break;
				case TypeFunction.Type.moveLeft:
					auxObstaclo.GetComponent<ObjetoMove>().MoveLeft();
					break;
				case TypeFunction.Type.moveRight:
					auxObstaclo.GetComponent<ObjetoMove>().MoveRight();
					break;
				}
			}
		}
	}

	void MoveTo(Transform bloco){
		if (bloco != null) {
			if (bloco.childCount != 0) {
				canMove = false;
				isMove = false;
			} else {
				this.transform.position = Vector2.MoveTowards (this.transform.position, moveTile.transform.position, playerVelocity*Time.deltaTime);
				if (this.transform.position == bloco.transform.position) {
					isMove = false;
				}
			}
		}
	}
}
