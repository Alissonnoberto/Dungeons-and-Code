using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {
	private static EnvironmentController instance;
	public static EnvironmentController Instance{
		get{
			if(instance == null){
				instance = FindObjectOfType<EnvironmentController> ();
			}
			return instance;
		}
	}

	[Header("Matriz")]
	public TileMatriz tileMatriz;


	[Header("Obstacles")]
	public List<Transform> obstaclo;
}
