using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ShopData",fileName = "DefaultShop")]
public class ShopData : ScriptableObject {

	public int id;
	public string ShopName;
	public float priceMultiplier;
	public List<InventoryItem> ItemsForSale;

}
