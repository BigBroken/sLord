using UnityEngine;
using System.Collections;

public class MainCharacterController : MonoBehaviour {

	public float moveSpeed = 4f;
	private Vector3 moveDirection;
	private Vector3 faceDirection;
	private CharacterController controller;
	private float offset;
	public Item itemSelected;
	public InventoryController inventory;
	public Transform handLocation;
	public GameObject itemHeld;
	public int indexSelected;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		offset = Camera.main.transform.position.y - transform.position.y;
		EventManager.StartListening ("UpdateHand", updateHand);
		indexSelected = 0;
	}

	void OnDisable() {
		EventManager.StopListening ("UpdateHand", updateHand);
	}

	void OnDestroy() {
		EventManager.StopListening ("UpdateHand", updateHand);
	}
	
	// Update is called once per frame
	void Update () {

		//character movement
		faceDirection = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, offset));
		transform.LookAt (new Vector3(faceDirection.x, transform.position.y, faceDirection.z));
		//character look
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		moveDirection = moveDirection.normalized * moveSpeed;
		controller.Move (moveDirection * Time.deltaTime);

		//item selection
		if(Input.GetButtonDown("Select1")) {
			indexSelected = 0;
			updateHand ();
		}
		//using items

		//using abilities
	}

	void OnTriggerEnter(Collider other) {
		//item pickups
		if(other.gameObject.tag == "Item"){
			inventory.addItem (other.gameObject.GetComponent<Item>());
		}
	}


	//updates the hand to hold selected item
	void updateHand() {
		Destroy (itemHeld);
		itemSelected = inventory.selectItem (indexSelected);
		if (itemSelected != null) {
			itemHeld = Instantiate (itemSelected.item.itemObject, handLocation.position, handLocation.rotation) as GameObject;
			itemHeld.transform.parent = gameObject.transform;
		}
	}
}
