using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ContinueOnClick : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Continue")){
			DialogueManager.Instance.SendMessage("OnConversationContinue");
		}
	}
}
