using UnityEngine;
using System.Collections;

public class displayRotation : MonoBehaviour {

	// Use this for initialization
	public Quaternion quaternion;
	void Start () {
		quaternion = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
