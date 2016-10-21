using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour {

	public string plantName;
	public float growth;
	public float growthRate;
	public int stage;
	public bool harvestable;
	public GameObject soilCell;
	public PlantData plantData;
	public MeshFilter meshFilter;

	public void Start(){
		soilCell = gameObject.transform.parent.gameObject;
		growth = 0.0f;
		growthRate = plantData.baseGrowthRate;
		stage = 0;
		meshFilter = GetComponent<MeshFilter> ();
	}

	public void grow() {
		//update growthRate
		if (!harvestable) {
			growthRate = plantData.baseGrowthRate;
			growth += growthRate;
			if (growth >= 100.0f) {
				growth -= 100;
				evolve ();
			}
		}
	}

	public void evolve() {
		stage++;
		if (stage == plantData.stages.Count - 1) {
			harvestable = true;
		} else {
			meshFilter.mesh = plantData.stages [stage];
		}
	}

	public void harvest() {
		stage--;
		harvestable = false;
		//spawn plant item
	}
}
