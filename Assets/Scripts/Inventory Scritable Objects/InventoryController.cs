using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {


	public List<Item> items = new List<Item> ();
	public int size = 28;
	public static InventoryController inventoryController;
	public GameObject slotPanel;
	public GameObject slot;
	public List<GameObject> slots = new List<GameObject> ();

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
		for (int i = 0; i < size; i++) {
			slots.Add (Instantiate(slot));
			slots [i].transform.SetParent (slotPanel.transform, false);
		}
	}
		

	public void addItem(Item item) {

		int index = items.FindIndex (Item => Item.item.itemName == item.item.itemName);
		Debug.Log (index);
		if (index >= 0 && items [index].numberStacked + item.numberStacked < items [index].item.maxStack)) {
				items [index].numberStacked += item.numberStacked;
				updateAmount (index);
		} else if (items.Count < size) {
			items.Add (item.clone());
			inventoryController.updateSprite (item, items.Count - 1);
			updateAmount(items.count - 1);
		} else {
			Debug.Log ("inventory is full");
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

	public void removeItem(InventoryItem item) {

	}
		

}
