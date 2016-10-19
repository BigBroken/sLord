﻿using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour  {

	public InventoryItem item;
	public int numberStacked = 1;
	[HideInInspector]public string itemName;

	void Start() {
		itemName = item.itemName;
	}

	// please note: this is a shallow clone only which is certain to cause troubles in the future.
	public Item clone()
	{
		return (Item) this.MemberwiseClone();
	}



}
