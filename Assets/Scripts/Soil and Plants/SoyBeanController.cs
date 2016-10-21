using UnityEngine;
using System.Collections;

public class SoyBeanController : MonoBehaviour {

	// Use this for initialization
	public string plantName = "Soy Bean";
	public float fullGrown = 12.0f;
	public GameObject soilCell;
	public Plant soyBean;

	void Start () {
//		EventManager.StartListening ("Grow", soyBean);
	}

	void onDisable() {
//		EventManager.StopListening ("Grow", soyBean);
	}

	void onDestroy() {
//		EventManager.StopListening ("Grow", soyBean);
	}	
	// Update is called once per frame
	void Update () {

	}
}
