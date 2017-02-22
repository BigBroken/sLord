using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CancelSleep : MonoBehaviour {

	void Start() {
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener (click);
	}
	void click() {
		EventManager.TriggerEvent ("SleepCancel");
		EventManager.TriggerEvent ("UnPause");
	}
}
