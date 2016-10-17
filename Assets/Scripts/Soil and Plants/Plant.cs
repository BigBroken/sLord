using UnityEngine;
using System.Collections;

public class Plant {


	public string name;
	public float age;
	public float fullGrown;
	public GameObject soilCell;
	public float growthRate;

	public Plant(string plantName, float plantFullGrown, GameObject plantSoilCell) {
		this.name = plantName;
		this.fullGrown = plantFullGrown;
		this.soilCell = plantSoilCell;
		this.growthRate = 1.0f;
		this.age = 0;
	}

	public void Grow() {
		//check if SoilCell conditions are met;
		//update growthRate
		this.age += this.growthRate;
	}
}
