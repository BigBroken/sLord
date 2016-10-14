using UnityEngine;
using System.Collections;

public class pauseController : MonoBehaviour {

	// Use this for initialization
	public static bool canPause = true;

	void Start(){
		EventManager.StartListening ("Pause", pause);
		EventManager.StartListening ("UnPause", unPause);
	}
	public void pause() {
		if (canPause) {
			Time.timeScale = 0;
			Debug.Log ("time.timescale = 0");
		}
	}
	public void unPause() {
		Time.timeScale = 1;
		Debug.Log ("time.timescale = 1");
	}
}
