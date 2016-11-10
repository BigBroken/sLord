using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class InventoryItemEditor : EditorWindow {

	public InventoryItemList inventoryItemList;
	private int viewIndex = 1;
	private string listName = "defaultName";
	private string itemName = "item1";

	[MenuItem ("Window/Inventory Item Editor %#e")]
	static void  Init () 
	{
		EditorWindow.GetWindow (typeof (InventoryItemEditor));
	}

	void  OnEnable () {
		if(EditorPrefs.HasKey("ObjectPath")) 
		{
			string objectPath = EditorPrefs.GetString("ObjectPath");
			inventoryItemList = AssetDatabase.LoadAssetAtPath (objectPath, typeof(InventoryItemList)) as InventoryItemList;
		}

	}

	void  OnGUI () {
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Inventory Item Editor", EditorStyles.boldLabel);
		if (inventoryItemList != null) {
			if (GUILayout.Button("Show Item List")) 
			{
				EditorUtility.FocusProjectWindow();
				Selection.activeObject = inventoryItemList;
			}
		}
		GUILayout.EndHorizontal ();

		if (inventoryItemList == null) 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.Space(10);
			if (GUILayout.Button("Create List", GUILayout.ExpandWidth(false))) 
			{
				CreateNewItemList(listName);
			}
			listName = GUILayout.TextField (listName, GUILayout.ExpandWidth(true));
			if (GUILayout.Button("Open Existing Item List", GUILayout.ExpandWidth(false))) 
			{
				OpenItemList();
			}
			GUILayout.EndHorizontal ();
		}

		GUILayout.Space(20);

		if (inventoryItemList != null) 
		{
			GUILayout.BeginHorizontal ();

			GUILayout.Space(10);

			if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false))) 
			{
				if (viewIndex > 1)
					viewIndex --;
			}
			GUILayout.Space(5);
			if (GUILayout.Button("Next", GUILayout.ExpandWidth(false))) 
			{
				if (viewIndex < inventoryItemList.itemList.Count) 
				{
					viewIndex ++;
				}
			}

			GUILayout.Space(60);

			if (GUILayout.Button("Add Item", GUILayout.ExpandWidth(false))) 
			{
				AddItem(itemName);
			}
			itemName = GUILayout.TextField (itemName, GUILayout.ExpandWidth(true));
			if (GUILayout.Button("Delete Item", GUILayout.ExpandWidth(false))) 
			{
				DeleteItem(viewIndex - 1);
			}

			GUILayout.EndHorizontal ();
			if (inventoryItemList.itemList == null)
				Debug.Log("Inventory Item List is null check InventoryItemList Script");
			if (inventoryItemList.itemList.Count > 0) 
			{
				GUILayout.BeginHorizontal ();
				viewIndex = Mathf.Clamp (EditorGUILayout.IntField ("Current Item", viewIndex, GUILayout.ExpandWidth(false)), 1, inventoryItemList.itemList.Count);
				//Mathf.Clamp (viewIndex, 1, inventoryItemList.itemList.Count);
				EditorGUILayout.LabelField ("of   " +  inventoryItemList.itemList.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();

				inventoryItemList.itemList[viewIndex-1].itemName = EditorGUILayout.TextField ("Item Name", inventoryItemList.itemList[viewIndex-1].itemName as string);
				inventoryItemList.itemList[viewIndex-1].itemIcon = EditorGUILayout.ObjectField ("Item Icon", inventoryItemList.itemList[viewIndex-1].itemIcon, typeof (Sprite), false) as Sprite;
				inventoryItemList.itemList[viewIndex-1].itemObject = EditorGUILayout.ObjectField ("Item Object", inventoryItemList.itemList[viewIndex-1].itemObject, typeof (GameObject), false) as GameObject;

				GUILayout.BeginHorizontal ();
				inventoryItemList.itemList[viewIndex-1].isUnique = (bool)EditorGUILayout.Toggle("Unique", inventoryItemList.itemList[viewIndex-1].isUnique, GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				inventoryItemList.itemList[viewIndex-1].isSeed = (bool)EditorGUILayout.Toggle("isSeed", inventoryItemList.itemList[viewIndex-1].isSeed,  GUILayout.ExpandWidth(false));
				if (inventoryItemList.itemList [viewIndex - 1].isSeed) {
					inventoryItemList.itemList[viewIndex-1].plant = EditorGUILayout.ObjectField ("plant prefab", inventoryItemList.itemList[viewIndex-1].plant, typeof (GameObject), false) as GameObject;

				}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				inventoryItemList.itemList[viewIndex-1].maxStack = EditorGUILayout.IntField("maxStack", inventoryItemList.itemList[viewIndex-1].maxStack, GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				inventoryItemList.itemList[viewIndex-1].destroyOnUse = (bool)EditorGUILayout.Toggle("Destroy On Use", inventoryItemList.itemList[viewIndex-1].destroyOnUse,  GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();

			} 
			else 
			{
				GUILayout.Label ("This Inventory List is Empty.");
			}
		}
//		if (GUI.changed) 
//		{
//			EditorUtility.SetDirty(inventoryItemList);
//		}
	}

	void CreateNewItemList (string listName) 
	{
		// There is no overwrite protection here!
		// There is No "Are you sure you want to overwrite your existing object?" if it exists.
		// This should probably get a string from the user to create a new name and pass it ...
		viewIndex = 1;
		inventoryItemList = CreateInventoryItemList.Create(listName);
		if (inventoryItemList) 
		{
			inventoryItemList.itemList = new List<InventoryItem>();
			string relPath = AssetDatabase.GetAssetPath(inventoryItemList);
			EditorPrefs.SetString("ObjectPath", relPath);
		}
	}

	void OpenItemList () 
	{
		string absPath = EditorUtility.OpenFilePanel ("Select Inventory Item List", "", "");
		if (absPath.StartsWith(Application.dataPath)) 
		{
			string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
			inventoryItemList = AssetDatabase.LoadAssetAtPath (relPath, typeof(InventoryItemList)) as InventoryItemList;
			if (inventoryItemList.itemList == null)
				inventoryItemList.itemList = new List<InventoryItem>();
			if (inventoryItemList) {
				EditorPrefs.SetString("ObjectPath", relPath);
			}
		}
	}

	void AddItem (string itemName) 
	{
		
		string path = AssetDatabase.GenerateUniqueAssetPath ("Assets/Resources/Items/"+itemName+".asset");
		InventoryItem newItem = ScriptableObject.CreateInstance<InventoryItem>();
		newItem.itemName = itemName;
		AssetDatabase.CreateAsset(newItem, path);
		inventoryItemList.itemList.Add (newItem);
		viewIndex = inventoryItemList.itemList.Count;
	}

	void DeleteItem (int index) 
	{
		//add functionality to deleteItem
		inventoryItemList.itemList.RemoveAt (index);
	}
}