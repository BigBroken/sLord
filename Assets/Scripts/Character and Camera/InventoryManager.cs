using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public InventoryController inventory;

	void start() {
//		inventory = 
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log (other);
		if(other.gameObject.tag == "Item"){
			Debug.Log ("We have collected the item");
			inventory.addItem (other.gameObject.GetComponent<Item>());
//			Destroy (other.gameObject);
		}
	}

}
