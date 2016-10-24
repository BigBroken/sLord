using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoilGridController : MonoBehaviour {

	public SoilCellController[] soilCells;
	public SoilData soilData;
	void Start() {
		DontDestroyOnLoad(gameObject);
		//Important note: place your prefabs folder(or levels or whatever) 
		//in a folder called "Resources" like this "Assets/Resources/Prefabs"
		soilCells = GetComponentsInChildren<SoilCellController>();
	}

	public void save() {
		soilData = new SoilData();
		soilData.isWatered = new bool[soilCells.Length];
		soilData.isSowed = new bool[soilCells.Length];
		soilData.plantId = new int[soilCells.Length];
		soilData.stage = new int[soilCells.Length];
		soilData.growth = new float[soilCells.Length];
		for (var i = 0; i < soilCells.Length; i++) {
			soilData.isWatered [i] = soilCells [i].isWatered;
			soilData.isSowed [i] = soilCells [i].isSowed;
			if (soilData.isSowed [i]) {
				soilData.plantId [i] = soilCells [i].plant.plantData.id;
				soilData.stage [i] = soilCells [i].plant.stage;
				soilData.growth [i] = soilCells [i].plant.growth;
			}
		}
	}
	public void load() {
		for (var i = 0; i < soilCells.Length; i++) {
			soilCells [i].isWatered = soilCells [i].isWatered;
			if(soilData.isSowed[i]) {
				soilCells [i].sow (soilData.plantId [i]);
				soilCells [i].plant.setStage (soilData.stage[i]);
				soilCells [i].plant.growth = soilData.growth [i];
			}

		}
	}
}
[System.Serializable]
public class SoilData {
	public bool[] isWatered;
	public bool[] isSowed;
	public int[] plantId;
	public int[] stage;
	public float[] growth;
}