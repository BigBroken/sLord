using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject sleepUI;

	void OnEnable () 
	{
		EventManager.StartListening ("SleepUI", sleep);
		EventManager.StartListening ("SleepCancel", sleepCancel);
	}
	void OnDisable () 
	{
		EventManager.StopListening ("SleepUI", sleep);
		EventManager.StopListening ("SleepCancel", sleepCancel);
	}
	void OnDestroy()
	{
		EventManager.StopListening ("SleepUI", sleep);
		EventManager.StopListening ("SleepCancel", sleepCancel);
	}

	void sleep(){
		sleepUI.SetActive (true);
	}
	void sleepCancel() {
		sleepUI.SetActive (false);
	}

	void Update() {
		if(Input.GetButtonDown("Inventory")) {
			Debug.Log ("Inventory triggered");
			EventManager.TriggerEvent ("ToggleInventory");
		}
	}
}
