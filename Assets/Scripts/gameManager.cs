using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public static gameManager Instance;
	private static pauseController pauseController;
	private static UIController uIController;
	public static GameObject UI;



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
//		pauseController.pause ();
//		uIController.sleep ();
//		sleepUI.gameObject.SetActive (true);
	}
}
