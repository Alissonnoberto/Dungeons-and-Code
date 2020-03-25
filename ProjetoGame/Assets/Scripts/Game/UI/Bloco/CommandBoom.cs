using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBoom : MonoBehaviour {

	AnimationEvent MyEvent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyYoursSelf(){
		Destroy (this.gameObject);
	}
}
