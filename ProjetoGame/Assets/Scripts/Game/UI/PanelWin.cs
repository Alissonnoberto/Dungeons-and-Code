using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelWin : MonoBehaviour {

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public Text points;

	public int pStar1;
	public int pStar2;
	public int pStar3;
	public int pMultiplier;

	public void StarsRate(){
		if (GameController.Instance.time < pStar2) {
			star1.SetActive (true);
		}
		else
		if (GameController.Instance.time < pStar3) {
			star1.SetActive (true);
			star2.SetActive (true);
		}
		else
		if (GameController.Instance.time >= pStar3) {
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);
		}
	}

	public void PointsRate(){		
		points.text = ((int)GameController.Instance.time * pMultiplier) + " Pontos".ToString ();
	}

	void Start () {
		StarsRate ();
		PointsRate ();		
	}

}
