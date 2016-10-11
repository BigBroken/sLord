using UnityEngine;
using System.Collections;

public class MainCharacterController : MonoBehaviour {

	public float moveSpeed = 4f;
	private Vector3 moveDirection;
	private Vector3 faceDirection;
	private CharacterController controller;
	private float offset;  

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		offset = Camera.main.transform.position.y - transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {

		faceDirection = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, offset));
		transform.LookAt (new Vector3(faceDirection.x, transform.position.y, faceDirection.z));

		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		moveDirection = moveDirection.normalized * moveSpeed;
		controller.Move (moveDirection * Time.deltaTime);
	}
}
