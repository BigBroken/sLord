using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	public int health;
	[HideInInspector]
	public GameObject target;
	public NavMeshAgent agent;
	public virtual void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}

	public void takeDamage(int damage) {
		health -= damage;
		if (health <= 0) {
			this.gameObject.SetActive (false);
			Destroy (gameObject);
		}
	}
}
