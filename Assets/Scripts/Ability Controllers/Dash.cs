using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability {
	public float distance;
	public float speed;
	public float skillResetTime;
	public float skillResetWindow;
	public bool skillResetReady;
	public bool skillFail;
	private IEnumerator skillCo;
	private IEnumerator cooldownCo;
//	public float skillResetTrue;
	// Use this for initialization
	void awake() {

	}
	void Start () {
		skillFail = false;
		skillResetReady = false;
		ready = true;
	}

	// Update is called once per frame
	public override void use ()
	{
		if (ready) {
			ready = false;
			gameManager.mainCharacterController.dash (distance, speed);
			gameManager.mainCharacterStats.energy -= energy;
			skillCo = skillReset ();
			cooldownCo = setCooldown ();
			StartCoroutine (skillCo);
			StartCoroutine (cooldownCo);
		} else if (!ready && skillResetReady) {
			StopCoroutine (skillCo);
			StopCoroutine (cooldownCo);
			ready = true;
		} else if (!ready && skillFail) {
			StopCoroutine (skillCo);
		}


	}
	public IEnumerator skillReset() {
		skillFail = true;
		skillResetReady = false;
		Debug.Log ("Skill fail time");
		yield return new WaitForSeconds (skillResetTime);
		Debug.Log ("Skill Reset Time");
		skillResetReady = true;
		yield return new WaitForSeconds (skillResetWindow);
		skillFail = false;
		skillResetReady = false;


	}
}
