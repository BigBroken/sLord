using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject sleepUI;
	public GameObject shopUI;
	public UIController uiController;
	public StatusUIController statusUI;
	public Image hitImage;
	public Color hitColor;
	public IEnumerator fadeCo;
	public float fadeTime;




	void Awake ()   
	{
		if (uiController == null)
		{
			DontDestroyOnLoad(gameObject);
			uiController = this;
		}
		else if (uiController != this) 
		{
			Destroy (gameObject);
		}
	}
	void Start (){
		hitColor = hitImage.color;
	}

	void OnEnable () 
	{
		EventManager.StartListening ("SleepUI", sleep);
		EventManager.StartListening ("SleepCancel", sleepCancel);
		EventManager.StartListening ("ToggleShopUI", toggleShopUI);
	}
	void OnDisable () 
	{
		EventManager.StopListening ("SleepUI", sleep);
		EventManager.StopListening ("SleepCancel", sleepCancel);
		EventManager.StopListening ("ToggleShopUI", toggleShopUI);

	}
	void OnDestroy()
	{
		EventManager.StopListening ("SleepUI", sleep);
		EventManager.StopListening ("SleepCancel", sleepCancel);
		EventManager.StopListening ("ToggleShopUI", toggleShopUI);

	}

	void sleep(){
		sleepUI.SetActive (true);
	}
	void sleepCancel() {
		sleepUI.SetActive (false);
	}

	void Update() {
		if(Input.GetButtonUp("Inventory")) {
			Debug.Log ("inventory pressed");
			Debug.Log ("Trigger toggle Inventory");
			EventManager.TriggerEvent ("ToggleInventory");
		}
	}
	void toggleShopUI() {

	}
	public void hit(float hits, float maxhits, float hitRecoveryTime){
		if (hits == maxhits) {
			StopCoroutine (fadeCo);
		} else {
			fadeCo = fadeLoop(hits/maxhits, 100);
			StartCoroutine (fadeCo);
		}

	}
	public IEnumerator fadeLoop(float alpha1, float alpha2) {
		while (true) {
			yield return new WaitForSeconds (10);
		}
	}
		
}
