using UnityEngine;
using System.Collections;

public class InventoryItem : ScriptableObject 
{
	public string itemName = "New Item";                                      //  What the item will be called in the inventory
	public Texture2D itemIcon = null;                                           //  What the item will look like in the inventory
	public Rigidbody itemObject = null;                                         //  Optional slot for a PreFab to instantiate when discarding
	public bool isUnique = false;                                               //  Optional checkbox to indicate that there should only be one of these items per game

//	public bool isStackable = false;                                            
	public int maxStack = 1;

	public bool destroyOnUse = true;                                          

	public bool isSeed = false;
	public GameObject plant = null;
}