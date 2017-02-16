using UnityEngine;
using System.Collections;

public class MainCharacterController : MonoBehaviour {

	public float moveSpeed = 4f;
	public float originalSpeed;
	private Vector3 moveDirection;
	private Vector3 faceDirection;
	private CharacterController controller;
	private float offset;
	public Item itemSelected;
	public InventoryController inventory;
	public Transform handLocation;
	public GameObject itemHeld;
	public int indexSelected;
	public gameManager gameManager;
	public CastingBar castBar;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}
	void Start () {
		controller = GetComponent<CharacterController>();
		originalSpeed = moveSpeed;
		offset = Camera.main.transform.position.y - transform.position.y;
		EventManager.StartListening ("UpdateHand", updateHand);
		EventManager.StartListening ("UseItem", useSelected);
		indexSelected = 0;
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<gameManager>();
	}

	void OnDisable() {
		EventManager.StopListening ("UpdateHand", updateHand);
		EventManager.StopListening ("UseItem", useSelected);
	}

	void OnDestroy() {
		EventManager.StopListening ("UpdateHand", updateHand);
		EventManager.StopListening ("UseItem", useSelected);
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
			if (indexSelected != 0) {
				indexSelected = 0;
				updateHand ();
			}

		}
		if(Input.GetButtonDown("Select2")) {
			if (indexSelected != 1) {
				indexSelected = 1;
				updateHand ();
			}
		}
		if(Input.GetButtonDown("Select3")) {
			if (indexSelected != 2) {
				indexSelected = 2;
				updateHand ();
			}
		}
		if(Input.GetButtonDown("Select4")) {
			if (indexSelected != 3) {
				indexSelected = 3;
				updateHand ();
			}
		}
		if(Input.GetButtonDown("Select5")) {
			if (indexSelected != 4) {
				indexSelected = 4;
				updateHand ();
			}
		}
		//using items
		if(Input.GetButtonDown("Fire1")) {

			if (itemSelected && itemSelected.item.isUsable) {
				//check if items off cool down else
				castBar.startCast (itemSelected.item);
				moveSpeed = moveSpeed * itemSelected.item.movementMod;

			}
		}
		if (Input.GetButtonUp ("Fire1")) {
			castBar.casting = false;
			moveSpeed = originalSpeed;

		}
		if (Input.GetButtonDown ("Test1")) {
			gameManager.save ();
		}
		if (Input.GetButtonDown ("Test2")) {
			gameManager.load ();
		}
	}

	void OnTriggerEnter(Collider other) {
		//item pickups
		if(other.gameObject.tag == "Item"){
			inventory.addItem (other.gameObject.GetComponent<Item>());
			Destroy (other.gameObject);
		}
	}


	//updates the hand to hold selected item
	void updateHand() {
		if (itemHeld != null) {
			itemHeld.transform.parent = inventory.inventoryContainer;

		}
		itemSelected = inventory.selectItem (indexSelected);
		if (itemSelected != null) {
			itemHeld = itemSelected.gameObject;
//			itemHeld = Instantiate (itemSelected.item.itemObject, handLocation.position + itemSelected.item.offset, this.transform.rotation * itemSelected.item.rotation) as GameObject;
			itemHeld.transform.parent = gameObject.transform;
			itemHeld.transform.position = handLocation.position;
			itemHeld.transform.rotation = this.transform.rotation * itemSelected.item.rotation;
			itemHeld.GetComponent<Item> ().disablePickUp ();

		}
		castBar.casting = false;
	}
	public void useSelected() {
		itemHeld.GetComponent<Item>().use ();
	}
}
