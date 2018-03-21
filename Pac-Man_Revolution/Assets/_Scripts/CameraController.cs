using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject pacman;
	private Vector3 offset;
	private GameController Controller;


	// Use this for initialization
	void Start () 
	{
		Controller = (GameController)GameObject.Find ("The Game").GetComponent("GameController");
		offset = transform.position - pacman.transform.position;
	}



	// Update is called once per frame
	void LateUpdate () 
	{
		if (!Controller.gameOver) 
		{
			transform.position = pacman.transform.position + offset;
		}
	}
}

