using UnityEngine;
using System.Collections;

public class SoilCellController : MonoBehaviour {


	//public dictionary plant type
	void Start () {
		EventManager.StartListening ("Sleep", NextDay);
	}
	void OnDisable(){
		EventManager.StopListening ("Sleep", NextDay);
	}
	void OnDestroy(){
		EventManager.StopListening ("Sleep", NextDay);
	}

	void NextDay () {
	
	}

	void Sow (int index) {
		Debug.Log(SoilGridController.plants [index]);
	}
}
