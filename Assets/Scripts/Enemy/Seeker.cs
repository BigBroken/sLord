using UnityEngine;
using System.Collections;

public class Seeker : Enemy {

	// Use this for initialization
	public float chaseDistance = 10.0f;
	private float targetDistance;
	public override void Start() {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		targetDistance = Vector3.Distance (target.transform.position, transform.position);
		if (targetDistance <= chaseDistance) {
			agent.SetDestination (target.transform.position);
		} else {
			agent.ResetPath ();
		}
	}
}
