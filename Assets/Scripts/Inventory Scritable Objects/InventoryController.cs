using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {



	public int size;
	public Item[] items;
	public static InventoryController inventoryController;
	public CanvasGroup canvasController;
	public GameObject slotPanel;
	public GameObject slot;
	public GameObject[] slots;
	public bool isActive;

	void Awake ()   
	{
		if (inventoryController == null)
		{
			DontDestroyOnLoad(gameObject);
			inventoryController = this;
		}
		else if (inventoryController != this) 
		{
			Destroy (gameObject);
		}
	}

	void Start() {
		size = 28;
		slots =  new  GameObject[size];
		items = new Item[size];
		for (int i = 0; i < slots.Length; i++) {
			slots[i] = Instantiate(slot);
			slots[i].transform.SetParent (slotPanel.transform, false);
		}
		isActive = false;
		EventManager.StartListening ("ToggleInventory", toggleInventory);
		canvasController = this.GetComponent<CanvasGroup> ();
	}

	void OnDestroy() {
		EventManager.StopListening ("ToggleInventory", toggleInventory);
	}

	public void toggleInventory(){
		Debug.Log ("Inventory toggled");
		isActive = !isActive;
		Debug.Log (isActive);
		if (isActive) {
			EventManager.TriggerEvent ("Pause");
		} else {
			EventManager.TriggerEvent ("UnPause");
		}
		canvasController.interactable = isActive;
		canvasController.blocksRaycasts = isActive;

		int convertedBool = isActive ? 1 : 0;
		canvasController.alpha = convertedBool;

	}

	public void addItem(Item item) {

		bool itemStacked = false;

		for( int i = 0; i < items.Length; i++) {
			if ( items[i] != null && items[i].item.itemName == item.item.itemName && items[i].numberStacked < items[i].item.maxStack) {
				if(items[i].numberStacked + item.numberStacked <= items[i].item.maxStack) {
					items[i].numberStacked += item.numberStacked;
					updateAmount(i);
					itemStacked = true;
					break;
				} else {
					item.numberStacked -= items[i].item.maxStack - items[i].numberStacked;
					items[i].numberStacked = items[i].item.maxStack;
					updateAmount (i);
				}
			}
		}
	   if (!itemStacked) {
			for (int i = 0; i < items.Length; i++) {
				if (items [i] == null) {
					items[i] = item.clone ();
					inventoryController.updateSprite (item, i);
					updateAmount(i);
					break;
				}
			}
		} 
	}
		

	public void updateSprite(Item item, int index) {
		
		slots [index].transform.GetChild(1).GetComponent<Image>().sprite = item.item.itemIcon;
	}

	public void updateAmount(int index) {
		slots [index].transform.GetChild (0).GetComponent<Text> ().text = items [index].numberStacked.ToString();
	}

	public void removeAtIndex(int index) {

	}

	public void removeItem(Item item) {

	}

}
