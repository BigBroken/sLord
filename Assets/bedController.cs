using UnityEngine;
using System.Collections;

public class bedController : MonoBehaviour {

	// Use this for initialization
	public Collider playerCollider;
	
	void OnTriggerEnter(Collider player) {
		gameManager.sleep ();
	}
}
