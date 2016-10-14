using UnityEngine;
using System.Collections;

public class forgeController : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	private Renderer rend;
	public float interactionDistance = 5.0f;


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

	void Update () {
		if(Input.GetButtonUp("Fire2")) {
//			Debug.Log (Vector3.Distance (transform.position, player.transform.position));
			if (Vector3.Distance (transform.position, player.transform.position) < interactionDistance) {
				//open forge screen
			}
		}
	
	}
}
