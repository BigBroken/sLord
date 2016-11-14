﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "InventoryItem",fileName = "defaultInventoryItem")]
public class InventoryItem : ScriptableObject 
{
	public string itemName = "New Item";   
	public string description = "";
	public int id = 0;// unique id for inventory
	public Sprite itemIcon = null;                                           //  What the item will look like in the inventory
	public GameObject itemObject = null;
	public Vector3 offset;
	public Quaternion rotation;
	//  Optional slot for a PreFab to instantiate when discarding
	public bool isUnique = false;                                                //  Optional checkbox to indicate that there should only be one of these items per game
	public int maxStack = 1;
	public bool destroyOnUse = true;                                          
	public bool isSeed = false;
	public GameObject plant = null;
	public int value = 0;
	public bool isWeapon = false;
	public float castTime = 0.0f;
	public GameObject weapon = null;
	public int damage = 0;
	public float movementMod = 1.0f;
	public GameObject projectile = null;

}
