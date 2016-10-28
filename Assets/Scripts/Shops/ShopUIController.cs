using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour {

//	public ShopUIController shopUIController;
	public MainCharacterStats mainCharacterStats;
	public InventoryController inventoryController;

	public GameObject[] slots;
	public GameObject shopSlot;
	public GameObject slotPanel;
	public CanvasGroup[] slotCanvi;
	public bool shopOpen = false;
	public int size = 25;
	public ShopData shopData;
	public CanvasGroup shopCanvasController;


//	void Awake ()   
//	{
//		if (shopUIController == null)
//		{
//			shopUIController = this;
//		}
//		else if (shopUIController != this) 
//		{
//			Destroy (gameObject);
//		}
//	}

	void Start() {
		slotPanel = gameObject.transform.GetChild (0).gameObject;
		slots = new GameObject[size];
		slotCanvi = new CanvasGroup[size];
		for (var i = 0; i < 25; i++) {
			slots[i] = Instantiate(shopSlot);
			slots[i].transform.SetParent (slotPanel.transform, false);
			ShopSlotHandler slotHandler = slots [i].GetComponent<ShopSlotHandler> ();
			slotHandler.index = i;
			slotHandler.shopUIController = this.GetComponent<ShopUIController> ();
			slotCanvi[i] = slots [i].GetComponent<CanvasGroup> ();
		}
		EventManager.StartListening ("ToggleInventory", exitShop);
	}
	void OnDestroy(){
		EventManager.StopListening ("ToggleInventory", exitShop);
	}
	void OnDisable(){
		EventManager.StopListening ("ToggleInventory", exitShop);
	}

	public void purchaseItem(int index){
//		Debug.Log ("item" + index + " purchased");
		int price = (int)((float)shopData.ItemsForSale [index].value * shopData.priceMultiplier);
		if (mainCharacterStats.mon >= price) {
			mainCharacterStats.mon -= price;
			inventoryController.addItem (shopData.ItemsForSale [index]);

		}
	}

	public void activateShopUI(ShopData data) {
		if (!shopOpen) {
			setItems (data);
			shopData = data;
			shopCanvasController.interactable = true;
			shopCanvasController.blocksRaycasts = true;
			shopCanvasController.alpha = 1.0f;
			inventoryController.toggleInventory ();
			shopOpen = true;
		}
	}

	public void setItems(ShopData data) {
		for (var i = 0; i < data.ItemsForSale.Count; i++) {
			slots[i].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = data.ItemsForSale [i].itemIcon;
			int price = (int)((float)data.ItemsForSale [i].value * data.priceMultiplier);
			slots[i].transform.GetChild (0).gameObject.GetComponent<Text> ().text = price.ToString("N0");
			slotCanvi [i].alpha = 1;
			slotCanvi [i].interactable = true;
			slotCanvi [i].blocksRaycasts = true;
		}
	}
	public void exitShop(){
		if (shopOpen) {
			deactivateShopUI ();
		}
	}
	public void deactivateShopUI() {
		shopCanvasController.interactable = false;
		shopCanvasController.blocksRaycasts = false;
		shopCanvasController.alpha = 0f;
		shopOpen = false;
	}

}
