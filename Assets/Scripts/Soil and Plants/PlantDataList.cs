using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "PlantDataList",fileName = "plantList")]
public class PlantDataList : ScriptableObject {
	public List<PlantData> plantDataList;
}
