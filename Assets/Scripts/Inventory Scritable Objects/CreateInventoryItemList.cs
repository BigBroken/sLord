using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateInventoryItemList {
	[MenuItem("Assets/Create/Inventory Item List")]
	public static InventoryItemList  Create(string ListName)
	{
		InventoryItemList asset = ScriptableObject.CreateInstance<InventoryItemList>();

		AssetDatabase.CreateAsset(asset, "Assets/Items/" + ListName + ".asset");
		AssetDatabase.SaveAssets();
		return asset;
	}
}