using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PacManController : MonoBehaviour {

	private Transform target;
	private NavMeshAgent agent;
	private GameController Controller;
	AudioSource sound;

	public GameObject playerDead;

	// Use this for initialization
	void Start () 
	{
		gameObject.transform.position = new Vector3 (0f, 1f, 0f);
		Controller = (GameController)GameObject.Find ("The Game").GetComponent("GameController");
		agent = gameObject.GetComponent<NavMeshAgent> ();
		sound = GetComponent<AudioSource> ();
		sound.pitch = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) 
			{
				agent.destination = hit.point;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "dot")
		{
			Controller.AddScore (10);
			sound.Play();
			//Destroy (other.gameObject);//这里可以直接写gameObject,因为默认是这个脚本里的gameObject
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "ghost")
		{
			gameObject.transform.position = new Vector3 (0f, 0.5f, 0f);
			Instantiate (playerDead, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			Controller.MinusLive (1);
		}
	}
}
