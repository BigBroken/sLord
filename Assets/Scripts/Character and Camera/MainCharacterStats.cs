using UnityEngine;
using System.Collections;

public class MainCharacterStats : MonoBehaviour {

	public StatusUIController statusUI;
	int _health;
	int _energy;
	int _mon;


	public int mon{
		get{ return _mon; }
		set{ _mon = value;
			updateMon ();
		}
	}
	public int health{
		get{ return _health; }
		set{ _health = value;
			updateHealth ();
		}
	}
	public int energy{
		get{ return _energy; }
		set{ _energy = value;
			updateEnergy ();
		}
	}
	// Use this for initialization

	void Start () {
		health = 150;
		energy = 20;
		mon = 0;
	}
	void OnDestroy(){
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

	void Update(){
		if (Input.GetButtonUp ("Select1")) {
			mon += 500;
		}
	}

}
