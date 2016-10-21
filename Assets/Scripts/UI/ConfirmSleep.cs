using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConfirmSleep : MonoBehaviour {

	void Start() {
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener (click);
	}
	void click() {
		EventManager.TriggerEvent ("NextDay");
		EventManager.TriggerEvent ("SleepCancel");  //Temporary for development
		EventManager.TriggerEvent ("UnPause");
	}
}
