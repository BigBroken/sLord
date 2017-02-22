using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	public static gameManager Instance;
	public string mainScene;
	private static pauseController pauseController;
	private static UIController uIController;
	public SoilGridController soilGridController;
	public InventoryController inventoryController;
	public MainCharacterController mainCharacterController;
	public MainCharacterStats mainCharacterStats;
	public Ability dash;




	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}

	public void save () {
		BinaryFormatter bf = new BinaryFormatter ();
		//inventory save
		FileStream file = File.Create (Application.persistentDataPath + "/saveInvo.dat");
		inventoryController.save();
		bf.Serialize (file, inventoryController.inventorySavedata);
		file.Close();

		//soil cell save
		file = File.Create (Application.persistentDataPath + "/saveSoil.dat");
		soilGridController.save ();
		bf.Serialize (file, soilGridController.soilData);
		file.Close ();
	}
	public void load () {
		if (File.Exists (Application.persistentDataPath + "/saveInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/saveInvo.dat", FileMode.Open);
			inventoryController.inventorySavedata = (InventorySaveData)bf.Deserialize (file);
			file.Close();
			inventoryController.load ();
		}
		if (File.Exists (Application.persistentDataPath + "/saveSoil.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/saveSoil.dat", FileMode.Open);
			soilGridController.soilData = (SoilData)bf.Deserialize (file);
			file.Close();
			soilGridController.load ();
			
		}
	}


}
