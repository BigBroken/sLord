using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusUIController : MonoBehaviour {

	//passed values from mainCharacterStatusController
	public Text monText;
	public Text healthText;
	public Text energyText;
	//passed values from timeController on game manager
	public Text timeText;
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
	public void updateTime(int time) {
		string period;
		string hour;
		string minute;
		if(time < 16){
			period = "am";

		} else {
			period = "pm";
		}

		if (time < 20) {
			hour = (time / 4 + 8).ToString ();
		} else {
			hour = (time / 4 - 4).ToString();
		}

		int remainder = time % 4;
		switch (remainder)
		{
		case 0:
			minute = "00";
			break;
		case 1:
			minute = "15";
			break;
		case 2:
			minute = "30";
			break;
		case 3:
			minute = "45";
			break;
		default:
			minute = "99";
			break;
		}
		timeText.text =  hour+":"+minute+""+period;
	}
}
