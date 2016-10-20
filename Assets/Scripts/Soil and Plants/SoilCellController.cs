using UnityEngine;
using System.Collections;

public class SoilCellController : MonoBehaviour {

	public bool isWatered = false;
//	public bool isMouseOver = false;
	public GameObject player;
	private Renderer rend;
	//public dictionary plant type
	void Start () {
		rend = GetComponent<Renderer>();
		if (player == null) {
			player = GameObject.FindWithTag ("Player");
		}
		EventManager.StartListening ("NextDay", NextDay);
	}
	void OnDisable(){
		EventManager.StopListening ("NextDay", NextDay);
	}
	void OnDestroy(){
		EventManager.StopListening ("NextDay", NextDay);
	}

	void NextDay () {
		//check weather
		isWatered = false;
	}

	void Sow (int index) {
		Debug.Log(SoilGridController.plants [index]);
	} 
		
	void OnMouseOver() {
		
		if (Input.GetButtonDown ("Fire1")) {
			if (Vector3.Distance(transform.position, player.transform.position) < 2.0f) {
				if (player.GetComponent<MainCharacterController> ().itemSelected != null) {
					if (player.GetComponent<MainCharacterController> ().itemSelected.item.isSeed) {
						//instantiate seeds plant object at soilcell transform
						//set plant objects parent to be soilcell
						EventManager.TriggerEvent("RemoveSelected");
						Debug.Log ("Remove Selected triggered");
					}
				}
			}
		}
	}
	void OnMouseEnter() {
//		rend.material.color = Color.red;
		Debug.Log ("mouseisout");
	}
	void OnMouseExit() {
					
		Debug.Log ("mouseisout");
	}
//
//	void OnTriggerStay(Collider other) {
//		if(other.tag == "Player") {
//			if (Input.GetButtonDown ("Fire1")) {
//				if (isMouseOver) {
//					//if selected inventory Item is type seed
//					EventManager.TriggerEvent ("Sow");
//					Debug.Log ("Sowing");
//				}
//			}
//		}
//	}
}
