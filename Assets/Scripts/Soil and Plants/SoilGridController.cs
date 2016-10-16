using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoilGridController : MonoBehaviour {

	public static GameObject[] plants;
	//I used this to keep track of the number of objects I spawned in the scene.
	public static int numSpawned = 0;

	void Start()
	{
		//Important note: place your prefabs folder(or levels or whatever) 
		//in a folder called "Resources" like this "Assets/Resources/Prefabs"
		plants = Resources.LoadAll<GameObject>("Prefabs/Plants");

	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
}
