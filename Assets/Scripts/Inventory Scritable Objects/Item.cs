using UnityEngine;
using System.Collections;


public class Item : MonoBehaviour  {
	public InventoryItem item;
	public int numberStacked = 1;
	private SphereCollider pickUp;

	void Start() {
		pickUp = gameObject.GetComponent<SphereCollider>() as SphereCollider;
	}
	// please note: this is a shallow clone only which is certain to cause troubles in the future.
	public Item clone()
	{
		return (Item) this.MemberwiseClone();
	}

	public void addPickUp(){
		pickUp.enabled = true;
	}

	public void removePickUp() {
		pickUp.enabled = false;
	}

}
