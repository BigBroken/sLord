using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "LootList",fileName = "DefaultLoot")]
public class LootList : ScriptableObject
{
	public int maxItemsDropped;
	public List<Loot> lootList;
	public InventoryItem requiredDrop;

}
