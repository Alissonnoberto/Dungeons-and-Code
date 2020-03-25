using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMove : MonoBehaviour {

	Transform moveTile;
	[Header("Direção da movimentação")]
	public TypeFunction.Type wereMove;

	[Header("Localização final da Pedra")]
	public Transform finalPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveTo (moveTile);
	}

	public void MoveUp(){
		if (this.transform.position != finalPoint.transform.position) {
			Transform auxLowestTile = null;
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
			moveTile = auxLowestTile.transform;
			this.transform.parent = auxLowestTile.transform;
		}
	}

	public void MoveRight(){
		if (this.transform.position != finalPoint.transform.position) {
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
			moveTile = auxLowestTile.transform;
			this.transform.parent = auxLowestTile.transform;
		}
	}

	public void MoveLeft(){
		if (this.transform.position != finalPoint.transform.position) {
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
			moveTile = auxLowestTile.transform;
			this.transform.parent = auxLowestTile.transform;
		}
	}

	public void MoveDown(){
		if (this.transform.position != finalPoint.transform.position) {
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
			moveTile = auxLowestTile.transform;
			this.transform.parent = auxLowestTile.transform;
		}
	}

	void MoveTo(Transform bloco){
		if (bloco != null) {
			this.transform.position = Vector2.MoveTowards (this.transform.position, bloco.transform.position, 1*Time.deltaTime);
		}
	}
}
