using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusUIController : MonoBehaviour {

	public Text monText;
	public Text healthText;
	public Text energyText;
	// Use this for initialization
	public void updateMon(int mon) {
		monText.text = mon.ToString () + " mon";
	}
	public void updateHealth(int health) {
		healthText.text = health.ToString () + " health";

	}
	public void updateEnergy(int energy) {
		energyText.text = energy.ToString () + " energy";
	}
}
