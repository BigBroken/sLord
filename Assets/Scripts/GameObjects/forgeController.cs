using UnityEngine;
using System.Collections;

public class forgeController : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public BoxCollider accessArea;
	private Renderer rend;


	void Start() {
		rend = GetComponent<Renderer>();
	}
	void OnMouseEnter() {
		//change to hammer cursor
		rend.material.color = Color.red;
	}
	// Update is called once per frame
	void OnMouseExit() {
		//change to default cursor
		rend.material.color = Color.white;
	}

	void OnTriggerStay(Collider other) {
		if(other.tag == "Player") {
			if (Input.GetButtonDown ("Fire2")) {
				EventManager.TriggerEvent ("ForgeUI");
				Debug.Log ("You can access the forge but its still just a wall");
			}
		}
	}
		
}
