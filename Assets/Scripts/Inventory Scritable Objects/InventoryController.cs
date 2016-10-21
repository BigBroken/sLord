using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {



	public int size;
	public int selected;
	public Item[] items;
	public static InventoryController inventoryController;
	public CanvasGroup canvasController;
	public GameObject slotPanel;
	public GameObject slot;
	public GameObject[] slots;
	public bool isActive;
	public Image empty;

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
		

	public void updateSprite(int index) {
		if (items [index] != null) {
			slots [index].transform.GetChild (1).GetComponent<Image> ().sprite = items [index].item.itemIcon;
			Color white = Color.white;
			slots [index].transform.GetChild (1).GetComponent<Image> ().color = white;
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

	//this function is not tested
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

}
