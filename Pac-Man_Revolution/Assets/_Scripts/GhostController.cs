using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GhostController : MonoBehaviour {

	NavMeshAgent agent;
	//private GameObject target;
	private Transform target;
	//target = GameObject.Find("PacMan");

	public Material[] matArray;
	//private Color[] colorArray = {Color.blue, Color.red, Color.cyan, Color.green};

	static int colorIndex = 0;

	private GameController Controller;

	private void Awake()
	{
		
		gameObject.GetComponentInChildren<Renderer>().material = matArray[colorIndex];
		colorIndex++;

		if (colorIndex > 4) {
			colorIndex = 0;
		}
	}

	void Start () 
	{
		Controller = (GameController)GameObject.Find ("The Game").GetComponent("GameController");
		agent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		//target = GameObject.Find("PacMan").GetComponent
		//target = GameObject.Find ("PacMan");
		//{
		//	Destroy (gameObject);
		//} else
		if (!Controller.gameOver)
		{			
			target = (Transform)GameObject.Find ("PacMan").GetComponent<Transform> ();
			agent.destination = target.transform.position; 
		}
	}


}
