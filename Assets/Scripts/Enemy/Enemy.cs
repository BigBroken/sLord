using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	public int health;
	[HideInInspector]
	public GameObject target;
	public UnityEngine.AI.NavMeshAgent agent;
	[HideInInspector]
	public LootController lootController;


	public virtual void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ();
		lootController = gameObject.GetComponent<LootController> ();
	}

	public void takeDamage(int damage) {
		health -= damage;
		if (health <= 0) {
			this.gameObject.SetActive (false);
			if (lootController) {
				lootController.onDeath ();
			}
			Destroy (gameObject);
		}
	}
}
