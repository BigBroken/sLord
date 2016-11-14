using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour {

	public InventoryItem item;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			Debug.Log (other.gameObject);
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
			Debug.Log (enemy.health);
			enemy.takeDamage (item.damage);
			gameObject.SetActive (false);
			Destroy (gameObject);
		}
	}

}
