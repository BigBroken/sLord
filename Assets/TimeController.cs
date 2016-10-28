using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {


	public StatusUIController statusUIController;
	public float quarterHourSeconds;
	//time will be converted by ui controller to a quarter hour time starting at 8:00am;
	public int time;
	private Coroutine passTime;

	void Start() {
		//in order to stop a coroutine a reference to it must be stored
		time = -1;
		quarterHourSeconds = 0.1f;
		passTime = StartCoroutine(incrementTime() );
		EventManager.StartListening ("NextDay", nextDay);
	}
	void OnDestroy() {
		EventManager.StopListening ("NextDay", nextDay);
	}
	void OnDisable() {
		EventManager.StopListening ("NextDay", nextDay);
	}
		
	void nextDay() {
		StopCoroutine (passTime);
		time = 0;
		statusUIController.updateTime (time);
		passTime = StartCoroutine (incrementTime());
	}

	IEnumerator incrementTime()
	{  
		yield return new WaitForSeconds(quarterHourSeconds);
		time++;
		statusUIController.updateTime(time);
		yield return passTime = StartCoroutine (incrementTime());;
	}
}
