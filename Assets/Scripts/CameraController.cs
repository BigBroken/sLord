using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	

	public GameObject player;       //Public variable to store a reference to the player game object


	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	private float screenXOffset;
	private float screenYOffset;
	private Vector3 screenOffset;
	public float maxCameraX = 10.0f;
	public float maxCameraY = 10.0f;
	private Vector3 mousePosition;
	// Use this for initialization
	void Start () 
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
	}


	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		//todo: add statement to check if cameraLock is enabled
		mousePosition = Input.mousePosition;
		screenXOffset = mousePosition.x - Screen.width / 2;
		if (screenXOffset >= 0) {
			screenXOffset = screenXOffset / Screen.width * maxCameraX;	
		} else if ( screenXOffset < 0 ) {
			screenXOffset = screenXOffset * (-1) / Screen.width * -maxCameraX;
		}

		screenYOffset = mousePosition.y - Screen.height / 2 ;
		if (screenYOffset >= 0) {
			screenYOffset = screenYOffset / Screen.height * maxCameraY;
		} else if ( screenYOffset < 0 ) {
			screenYOffset = screenYOffset * (-1) / Screen.height * -maxCameraY;
		}
		screenOffset = new Vector3 (screenXOffset, 0, screenYOffset);

		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset + screenOffset;

	}
}
