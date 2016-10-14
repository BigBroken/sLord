using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public static gameManager Instance;
	private pauseController pauseController;



	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
			pauseController = GetComponent<pauseController> ();
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}

	public static void sleep () {
		pauseController.pause ();
	}
}
