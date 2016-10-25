using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameUIController : MonoBehaviour {

	public Text monDisplay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void updateMon(int mon){
		monDisplay.text = mon + "mon";
	}
}
