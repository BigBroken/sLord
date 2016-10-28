using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using System;
      
public class InventoryController : MonoBehaviour {



	public int size;
	public int selected;
	public Item[] items;
	public InventoryController inventoryController;
	public CanvasGroup canvasController;
	public GameObject slotPanel;
	public GameObject slot;
	public GameObject[] slots;
	public bool isActive;
	public bool isShopOpen;
	public Image empty;
	public InventoryItemList inventoryItemDB;

	public InventorySaveData inventorySavedata;

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
			slots [i].GetComponent<slotController> ().index = i;
		}
		selected = 0;
		isActive = false;
		EventManager.StartListening ("ToggleInventory", toggleInventory);
		EventManager.StartListening ("RemoveSelected", removeSelected);

		canvasController = this.GetComponent<CanvasGroup> ();
	}

	void OnDestroy() {
		EventManager.StopListening ("ToggleInventory", toggleInventory);
		EventManager.StopListening ("RemoveSelected", removeSelected);
	}

	public void toggleInventory() {
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
		
	public InventoryItem findItem(int id){
		foreach (InventoryItem item in inventoryItemDB.itemList) {
			if (item.id == id) {
				return item;
			}
		}
		return null;
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
					updateSprite (i);
					updateAmount(i);
					if (i == selected) {
						EventManager.TriggerEvent("UpdateHand");
					}
					break;
				}
			}
		} 
	}

	public void addItem(InventoryItem item){
		addItem (item.itemObject.GetComponent<Item> ());
	}

	public void switchItems(int index1, int index2){
		if (items [index1] != null) {
			Item tempItem = items [index1].clone ();
		
				items [index1] = items [index2];
			
			items [index2] = tempItem;
		}
		updateSprite (index1);
		updateSprite(index2);
		updateAmount (index1);
		updateAmount (index2);
		if (index1 == selected || index2 == selected) {
			EventManager.TriggerEvent ("UpdateHand");
		}
	}

	public void updateSprite(int index) {
		if (items [index] != null) {
			Debug.Log (items [index].item);
			slots [index].transform.GetChild (1).GetComponent<Image> ().sprite = items [index].item.itemIcon;
			slots [index].transform.GetChild (1).GetComponent<Image> ().color = Color.white;
		} else {
			Color clear = Color.clear;
			slots [index].transform.GetChild (1).GetComponent<Image> ().color = clear;
		}

	}

	public void updateAmount(int index) {
		if (items[index] == null) {
			slots [index].transform.GetChild (0).GetComponent<Text> ().text = "";
		} else if (items [index].numberStacked <= 0) {
			removeAtIndex (index);
		} else {
			slots [index].transform.GetChild (0).GetComponent<Text> ().text = items [index].numberStacked.ToString();
			slots [index].transform.GetChild (0).GetComponent<Text> ().color = Color.white;
		}
	}

	public void removeAtIndex(int index) {
		items [index] = null;
		updateAmount (index);
		updateSprite (index);
		if (index == selected) {
			EventManager.TriggerEvent ("UpdateHand");
			Debug.Log ("UpdateHand");
		}
	}

	public void removeSelected() {
		items [selected].numberStacked-= 1;
		updateAmount (selected); 
	}

	public void removeSelected( int amount) {
		items [selected].numberStacked-= amount;
		updateAmount (selected);
	}

//	tdhis function is not tested
	public void removeItem(Item item) {
		for (int i = 0; i < items.Length; i++) {
			if (items [i] != null && items [i].item.itemName == item.item.itemName) {
				if (items [i].numberStacked <= item.numberStacked) {
					items [i].numberStacked -= item.numberStacked;
					updateAmount (i);
					break;
				}
			}
		}
	}


	public Item selectItem(int index) {
		if (items [index] != null) {
			selected = index;
		}
		return items [index];
	}

	public void handleSow() {
		removeSelected();
	}


	public void save() {
		inventorySavedata = new InventorySaveData ();
		inventorySavedata.ids = new int[size];
		inventorySavedata.stacks = new int[size];
		for (var i = 0; i < size; i++) {
			if (items [i] != null) {
				inventorySavedata.ids [i] = items [i].item.id;
				inventorySavedata.stacks [i] = items [i].numberStacked;
			}
		}
	}

	public void load() {
		for (var i = 0; i < size; i++) {
			if (inventorySavedata.ids [i] != 0) {
				Debug.Log(inventorySavedata.ids [i]);
				InventoryItem tempInventoryItem = findItem (inventorySavedata.ids [i]);
				Item tempItem = tempInventoryItem.itemObject.GetComponent<Item>().clone ();
				items [i] = tempItem;
				items [i].numberStacked = inventorySavedata.stacks [i];
				updateSprite (i);
				updateAmount (i);
			}
		}
		selected = inventorySavedata.selected;
		EventManager.TriggerEvent("UpdateHand");
	}

		
}

[System.Serializable]
public class InventorySaveData {
	//save and load variables
	[SerializeField]
	public int selected;
	[SerializeField]
	public int[] ids;
	[SerializeField]
	public int[] stacks;

}
	



