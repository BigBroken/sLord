﻿using UnityEngine;
using System.Collections;

public class MainCharacterController : MonoBehaviour {

	public float moveSpeed = 4f;
	private Vector3 moveDirection;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		moveDirection = moveDirection.normalized * moveSpeed;
		controller.Move (moveDirection * Time.deltaTime);
	}
}
