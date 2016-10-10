using UnityEngine;
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
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		Debug.Log (moveDirection);
		moveDirection = moveDirection.normalized * moveSpeed;
		controller.Move (moveDirection * Time.deltaTime);
	}
}
