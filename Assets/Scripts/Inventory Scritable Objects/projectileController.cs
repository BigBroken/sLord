using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour {

	public InventoryItem item;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
			enemy.takeDamage (item.damage);
			gameObject.SetActive (false);
			Destroy (gameObject);
		}
	}

}
