using UnityEngine;
using System.Collections;

public class shopController : MonoBehaviour {

	public ShopData shopData;
	public float interactableDistance;
	public GameObject player;
	public ShopUIController shopUIController;
	// Use this for initialization
	void Start () {
		interactableDistance = 3.0f;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	// Update is called once per frame

	void OnMouseOver () {
		if (Input.GetButtonDown ("Fire1")) {
			if (Vector3.Distance (player.transform.position, gameObject.transform.position) <= interactableDistance) {
				shopUIController.activateShopUI (shopData);
			}
		}
	}

}
