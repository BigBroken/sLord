using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject sleepUI;
	public GameObject shopUI;
	public UIController uiController;
	public CanvasGroup shopCanvasController;


	void Awake ()   
	{
		if (uiController == null)
		{
			DontDestroyOnLoad(gameObject);
			uiController = this;
		}
		else if (uiController != this) 
		{
			Destroy (gameObject);
		}
	}

	void OnEnable () 
	{
		EventManager.StartListening ("SleepUI", sleep);
		EventManager.StartListening ("SleepCancel", sleepCancel);
		EventManager.StartListening ("ToggleShopUI", toggleShopUI);
	}
	void OnDisable () 
	{
		EventManager.StopListening ("SleepUI", sleep);
		EventManager.StopListening ("SleepCancel", sleepCancel);
		EventManager.StopListening ("ToggleShopUI", toggleShopUI);

	}
	void OnDestroy()
	{
		EventManager.StopListening ("SleepUI", sleep);
		EventManager.StopListening ("SleepCancel", sleepCancel);
		EventManager.StopListening ("ToggleShopUI", toggleShopUI);

	}

	void sleep(){
		sleepUI.SetActive (true);
	}
	void sleepCancel() {
		sleepUI.SetActive (false);
	}

	void Update() {
		if(Input.GetButtonUp("Inventory")) {
			Debug.Log ("inventory pressed");
			Debug.Log ("Trigger toggle Inventory");
			EventManager.TriggerEvent ("ToggleInventory");
		}
	}
	void toggleShopUI() {

	}
		
}
