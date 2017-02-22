using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {
	public gameManager gameManager;
	public float cooldown;
	public int energy;
	public bool ready;
	// Use this for initialization

	void Start(){
	}
	public virtual void use() {
		if (ready && energy >= gameManager.mainCharacterStats.energy ) {
			ready = false;
			gameManager.mainCharacterStats.energy -= energy;
			setCooldown ();
		}
	}
	public IEnumerator setCooldown(){
		yield return new WaitForSeconds(cooldown);
		ready = true;
	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
}
