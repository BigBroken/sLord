using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "PlantData",fileName = "DefaultPlant")]
public class PlantData : ScriptableObject {

	public int id;
	public string plantName;
	public float baseGrowthRate;
	public GameObject plantPrefab;
	public List<Mesh> stages;
	public InventoryItem harvestItem;

}
