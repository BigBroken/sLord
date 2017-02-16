using UnityEngine;
using System.Collections;

public class projectileWeapon : Item {

	// Use this for initialization
	public GameObject projectile;
	public Transform handLocation;
	//range
	public float speed = 10.0f;


	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void use () {
		base.use ();
		Quaternion direction = gameObject.transform.parent.rotation;
		GameObject proj = (GameObject)Instantiate (projectile, this.gameObject.transform.position, direction * item.rotation);
		proj.GetComponent<Rigidbody>().velocity = direction * Vector3.forward  * speed;
	}
}
