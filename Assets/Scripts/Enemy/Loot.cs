using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Loot",fileName = "defaultLoot")]
public class Loot : ScriptableObject 
{

	public InventoryItem Item;
	public float dropChance;
}
