using UnityEngine;
using System.Collections;

[System.Serializable]
public class InventoryItem : ScriptableObject 
{
	public string itemName = "New Item";   
	public int id = 0;// unique id for inventory
	public Sprite itemIcon = null;                                           //  What the item will look like in the inventory
	public GameObject itemObject = null;                                         //  Optional slot for a PreFab to instantiate when discarding
	public bool isUnique = false;                                                //  Optional checkbox to indicate that there should only be one of these items per game
	public int maxStack = 1;
	public bool destroyOnUse = true;                                          
	public bool isSeed = false;
	public GameObject plant = null;


}
