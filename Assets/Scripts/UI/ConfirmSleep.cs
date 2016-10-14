using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConfirmSleep : MonoBehaviour {

	void Start() {
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener (click);
	}
	void click() {
		EventManager.TriggerEvent ("Sleep");
		EventManager.TriggerEvent ("UnPause");
	}
}
