﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	
	public AudioSource stageMusic;

	void Awake () {
		stageMusic.Play ();
	}

	void Update () {
		
	}
}