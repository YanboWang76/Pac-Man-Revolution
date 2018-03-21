using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour {


	//AudioSource m_MyAudioSource;
	// Use this for initialization
	void Start () 
	{
		
		//m_MyAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "pac man")
		{
			//m_MyAudioSource.Play();
			Destroy (gameObject);//这里可以直接写gameObject,因为默认是这个脚本里的gameObject
		}
	}
}
