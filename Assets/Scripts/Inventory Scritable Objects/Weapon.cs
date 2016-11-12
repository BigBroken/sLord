using UnityEngine;
using System.Collections;

public class Weapon : Item {

	// Use this for initialization
	public GameObject projectile;
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void use () {
		Debug.Log (gameObject.transform.position);
		base.use ();
		GameObject proj = (GameObject)Instantiate (projectile, this.gameObject.transform.position, Quaternion.identity);
		proj.GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
	}
}
