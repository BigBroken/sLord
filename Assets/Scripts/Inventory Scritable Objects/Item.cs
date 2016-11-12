using UnityEngine;
using System.Collections;


public class Item : MonoBehaviour  {
	public InventoryItem item;
	public int numberStacked = 1;
	public bool enablePickup = false;
	private SphereCollider pickUp;

	public virtual void Start() {
		pickUp = gameObject.GetComponent<SphereCollider>() as SphereCollider;
		if (enablePickup) {

		} else {
			pickUp.enabled = false;
		}
	}
	// please note: this is a shallow clone only which is certain to cause troubles in the future.
	public Item clone()
	{
		return (Item) this.MemberwiseClone();
	}

	public void enablePickUp(){
		pickUp.enabled = true;
	}

	public void disablePickUp() {
		pickUp.enabled = false;
	}

	public virtual void use() {
		if (item.destroyOnUse) {
			EventManager.TriggerEvent ("RemoveSelected");
		}
		
	}
}
