using UnityEngine;
using System.Collections;

public class bedController : MonoBehaviour {

	// Use this for initialization
	public Collider playerCollider;
	
	void OnTriggerEnter(Collider other) {
		if ( other.tag == "Player" ) {
			EventManager.TriggerEvent("SleepUI");
			EventManager.TriggerEvent ("Pause");
		}
	}
}
