using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class gameManager : MonoBehaviour {

	public gameManager Instance;
	private static pauseController pauseController;
	private static UIController uIController;
	public SoilCellController SoilCellController;
	public InventoryController inventoryController;




	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
			pauseController = GetComponent<pauseController> ();
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}

	public void save () {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/saveInfo.dat");
		inventoryController.save();
		bf.Serialize (file, inventoryController.inventorySavedata);
		file.Close();
	}
	public void load () {
		if (File.Exists (Application.persistentDataPath + "/saveInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/saveInfo.dat", FileMode.Open);
			inventoryController.inventorySavedata = (InventorySaveData)bf.Deserialize (file);
			file.Close();
			inventoryController.load ();
		}
	}


}
