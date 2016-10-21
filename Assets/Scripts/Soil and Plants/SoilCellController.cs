using UnityEngine;
using System.Collections;

public class SoilCellController : MonoBehaviour {

	public bool isWatered;
	public bool isSowed = false;
	public float interactableDistance = 2.0f;
	public GameObject player;
	public MainCharacterController playerController;
	private Renderer rend;
	public GameObject plantObject;
	public Plant plant;

	void Start () {
		rend = GetComponent<Renderer>();
		if (player == null) {
			player = GameObject.FindWithTag ("Player");
			playerController = player.GetComponent<MainCharacterController> ();
		}
		EventManager.StartListening ("NextDay", nextDay);
		isWatered = true;
	}
	void OnDisable(){
		EventManager.StopListening ("NextDay", nextDay);
	}
	void OnDestroy(){
		EventManager.StopListening ("NextDay", nextDay);
	}

	void nextDay () {
		Debug.Log ("NextDay called");
		if (isWatered && isSowed) {
			Debug.Log ("growCalled");
			plant.grow ();
		} else if(isWatered) {
			//percentage chance for something wild to grow
		} else {
			//percentage chance for something wild to grow
		}
//		isWatered = false;
	}

	void sow () {
		plantObject = Instantiate(playerController.itemSelected.item.plant,gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		plantObject.transform.parent = gameObject.transform;
		isSowed = true;
		EventManager.TriggerEvent("RemoveSelected");
		plant = plantObject.GetComponent<Plant> ();
	} 

	void raining() {
		isWatered = true;
	}

	void OnMouseOver() {
		if (Input.GetButtonDown ("Fire1")) {
			if (Vector3.Distance(transform.position, player.transform.position) < interactableDistance) {
				if (playerController.itemSelected != null) {
					if (playerController.itemSelected.item.isSeed && !isSowed) {
						sow ();
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
