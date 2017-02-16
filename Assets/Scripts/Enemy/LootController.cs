using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootController : MonoBehaviour {

	public LootList lootList;

	public void onDeath() {
		if (lootList.requiredDrop) {
			drop (lootList.requiredDrop);
		} else {
			calculateDrop ();
		}
	}

	public void drop (InventoryItem item) {
		Instantiate(item.itemObject, gameObject.transform.position, item.rotation);
	}
	public void calculateDrop () {
		float randomChance = Random.value;
		for (int i = 0; i < lootList.lootList.Count; i++)
		{
			if (lootList.lootList [i].dropChance > randomChance) {
				drop (lootList.lootList [i].Item);
				return;
			}
		}
	}
}
