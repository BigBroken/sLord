using UnityEngine;
//using System.Collections;
//
//public class CooldownController : MonoBehaviour {
//
//	public bool dashReady;
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	public IEnumerator activateCooldown(float delay, System.Action operation) {
//		yield return new WaitForSeconds(delay);
//		operation();
//	}
//	public void setDash(float dashCooldown) {
//	  dashReady = false;
//	  StartCoroutine(activateCooldown(dashCooldown, ()=>dashReady = true));
//	}
//}
