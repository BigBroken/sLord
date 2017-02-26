using UnityEngine;
using System.Collections;

public class MainCharacterStats : MonoBehaviour {

	public StatusUIController statusUI;
	public UIController UIController;
	int _health;
	int _energy;
	int _mon;
	public int maxHits;
	public int hits;
	public float hitRecoveryTime;
	public IEnumerator recoveryCo;
	public bool recovering;

	public int mon {
		get { return _mon; }
		set { _mon = value;
			updateMon ();
		}
	}
	public int health {
		get { return _health; }
		set { _health = value;
			updateHealth ();
		}
	}
	public int energy {
		get { return _energy; }
		set { _energy = value;
			updateEnergy ();
		}
	}
	// Use this for initialization

	void Start () {
		health = 150;
		energy = 20;
		mon = 0;
	}

	void OnDestroy() {
	
	}

	void OnDisable() {
		
	}


	public void updateMon() {
		statusUI.updateMon(mon);
	}
	public void updateHealth() {
		statusUI.updateHealth(health);
	}
	public void updateEnergy() {
		statusUI.updateEnergy(energy);
	}

	public void setHealth(int newHealth){
//		health = newHealth;
//		StatusUIController.updateHealth (health);
	}
	public void hit (int dmg = 1) {
		hits -= dmg;
		if (hits <= 0) {
			die ();
		} else { 
			if (recovering) {
				StopCoroutine (recoveryCo);
			}
			recoveryCo = recover ();
			StartCoroutine (recoveryCo);
			UIController.hit (hits, maxHits, hitRecoveryTime);
		}
	}

	public IEnumerator recover() {
		recovering = true;
		yield return new WaitForSeconds (hitRecoveryTime);
		if (hits < maxHits) {
			hits++;
		}
		recovering = false;
		UIController.hit (hits,maxHits,hitRecoveryTime);

	}

	public void die() {

	}

	void Update(){
		if (Input.GetButtonUp ("Select1")) {
			mon += 500;
		}
	}

}
