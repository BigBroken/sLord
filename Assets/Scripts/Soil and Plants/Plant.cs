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
		growthRate = plantData.baseGrowthRate;
		meshFilter = GetComponent<MeshFilter> ();
		meshFilter.mesh = plantData.stages [stage];
	}

	public void grow() {
		//update growthRate
		if (!harvestable) {
			growthRate = plantData.baseGrowthRate;
			growth += growthRate;
			if (growth >= 100.0f) {
				growth -= 100;
				setStage (stage++);
			}
		}
	}



	public void setStage(int newStage) {
			if (stage == plantData.stages.Count - 1) {
				meshFilter.mesh = plantData.stages [stage];
				harvestable = true;
			} else {
				meshFilter.mesh = plantData.stages [stage];
			}
	}

	public void harvest() {
		setStage (stage--);
		harvestable = false;
		growth = 0.0f;
		Instantiate (plantData.harvestItem.itemObject, gameObject.transform.position, gameObject.transform.rotation);
	}
}
