using UnityEngine;
using System.Collections;

public class pauseController : MonoBehaviour {

	// Use this for initialization
	public static bool canPause = true;

	public static void pause() {
		if (canPause) {
			Time.timeScale = 0;
			Debug.Log ("time.timescale = 0");
		}
	}
	public static void unpause() {
		Time.timeScale = 1;
	}
}
