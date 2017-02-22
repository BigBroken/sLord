using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class DashController : MonoBehaviour {
//	public gameManager gameManager;
//	public float dashDistance;
//	public float dashSpeed;
//	public float dashCooldown;
//	public bool dashEnabled;
//	// Use this for initialization
//	void awake() {
//
//	}
//	void Start () {
//		dashDistance = 5.0f;
//		dashSpeed = 25.0f;
//		dashCooldown = 5.0f;
//		
//	}
//	
//	// Update is called once per frame
//	public void dash () {
//		if (dashEnabled) {
//			if (gameManager.cooldownController.dashReady) {
//				gameManager.mainCharacterController.dash (dashDistance, dashSpeed);
//				gameManager.cooldownController.setDash (dashCooldown);
//			} else {
////				gameManager.cooldownController.dashInfo();
//			}
//		} 
//	}
//}
