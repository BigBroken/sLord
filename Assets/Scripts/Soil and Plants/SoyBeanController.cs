using UnityEngine;
using System.Collections;

public class SoyBeanController : MonoBehaviour {

	// Use this for initialization
	public string plantName = "Soy Bean";
	public float fullGrown = 12.0f;
	public GameObject soilCell;
	public Plant soyBean;

	void Start () {
		soyBean = new Plant (plantName, fullGrown, soilCell);
		EventManager.StartListening ("Grow", soyBean.Grow);
	}

	void onDisable() {
		EventManager.StopListening ("Grow", soyBean.Grow);
	}

	void onDestroy() {
		EventManager.StopListening ("Grow", soyBean.Grow);
	}	
	// Update is called once per frame
	void Update () {

	}
}
