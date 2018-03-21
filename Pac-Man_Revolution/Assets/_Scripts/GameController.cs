using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public bool gameOver;

	public GameObject pacMan;
	public GameObject ghostPrefab;
	public GameObject dotPrefab;

	public GameObject txtScore;
	public GameObject txtLive;
	public GameObject gameOverNotice;

	//private float timeElapsed;

	//AudioSource sound;


	//private int delay;
	private int dotCount;
	private int score;
	private int live;

	private void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		} 
		else if (instance != this)
		{
			Destroy (gameObject);
		}
		gameOver = false;
	}


	public void AddScore(int delta)
	{
		score += delta;
		txtScore.GetComponent<TextMesh>().text = "Scores: " + score;
	}

	public void MinusLive(int delta)
	{
		if (!gameOver)
		{
			live = live - delta;
			txtLive.GetComponent<TextMesh>().text = "\n"+"Lives: " + live;
		}
	}



	// Use this for initialization
	void Start () 
	{
		//delay = Random.Range (6, 9);
		//dotCount = 1;

		score = 0;
		txtScore.GetComponent<TextMesh>().text = "Scores: " + score;
		live = 3;

		dotCount = 100;

		txtLive.GetComponent<TextMesh>().text = "\n"+"Lives: " + live;
		int sysSecond = System.DateTime.Now.Second;
		//Debug.Log (sysSecond);
		//timeElapsed = 0f;

		//pacMan.transform.position = new Vector3 (0f, 1f, 0f);

		Vector3 spawnOffset1 = new Vector3(-4.5f, 0.25f, -4.5f);
		Vector3 spawnOffset2 = new Vector3(4.5f, 0.25f, -4.5f);
		Vector3 spawnOffset3 = new Vector3(-2.5f, 0.25f, -2.5f);
		Vector3 spawnOffset4 = new Vector3(2.5f, 0.25f, -2.5f);
		Instantiate(ghostPrefab, transform.position + spawnOffset1, transform.rotation);
		Instantiate(ghostPrefab, transform.position + spawnOffset2, transform.rotation);
		Instantiate(ghostPrefab, transform.position + spawnOffset3, transform.rotation);
		Instantiate(ghostPrefab, transform.position + spawnOffset4, transform.rotation);

		//Vector3 dotOffset = new Vector3 (-4.5f, 0f, 4.5f);
		//Instantiate (dotPrefab, transform.position + dotOffset, transform.rotation);
		for(float i = -4.5f; i <= 4.5f; i++)
		{
			for (float j = 4.5f; j >= -4.5f; j--) 
			{
				if (sysSecond % 4 != 0) 
				{
					Vector3 dotOffset = new Vector3 (i, 0f, j);
					Instantiate (dotPrefab, transform.position + dotOffset, transform.rotation);
					sysSecond++;
				} 
				else 
				{
					sysSecond++;
					dotCount--;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (live == 0) 
		{
			gameOver = true;
		}

		if(score == dotCount * 10)
		{
			gameOverNotice.GetComponent<TextMesh>().text = "Congratulations!" + "\n" + "You beat the game!" + "\n" + 
				"Your Score: " + score + "\n" + "Press R to try again"; //If you see score adding up after game overs, it is actually a feature.
			gameOver = true;
		
		}

		if (gameOver)
		{
			//ghostPrefab.gameObject.SetActive(false);
			//pacMan.gameObject.SetActive(false);
			gameOverNotice.transform.position = pacMan.transform.position;
			Destroy (pacMan);
			gameOverNotice.GetComponent<TextMesh>().text = "Game Over!" + "\n" + 
			"Your Score: " + score + "\n" + "Better luck next time!";
		}

		//if (gameOver && Input.GetKeyDown(KeyCode.R))
		//{
		//	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		//}
	}
}
