using UnityEngine;
using System.Collections;

public class MainCharacterStats : MonoBehaviour {

	public static GameUIController gameUI;
	public int health;
	public int energy;
	public int mon;
	// Use this for initialization
	void Start () {
		health = 150;
		energy = 20;
		mon = 0;
		EventManager.StartListening ("UpdateMon", updateMon);
	}
	void OnDestroy(){
		EventManager.StopListening ("UpdateMon", updateMon);
	}
	void OnDisable() {
		EventManager.StopListening ("UpdateMon", updateMon);
	}

	public void updateMon() {
		gameUI.updateMon(mon);
	}

}
