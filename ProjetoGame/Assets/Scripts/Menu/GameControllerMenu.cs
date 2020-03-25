using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerMenu : MonoBehaviour {

	private static GameControllerMenu instance;
	public static GameControllerMenu Instance{
		get{
			if (instance == null){
				instance = FindObjectOfType<GameControllerMenu> ();
			}
			return instance;
		}
	}
	public UIControllerMenu UIControllerMenu;
}
