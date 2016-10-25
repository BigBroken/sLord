using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler {

	private GameObject ghost;
	public InventoryController inventoryController;
	Vector3 startPosition;
	Transform startParent;
	void Start(){
		inventoryController = transform.parent.transform.parent.transform.parent.GetComponent<InventoryController> ();
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		ghost = (Instantiate (gameObject, gameObject.transform.position, gameObject.transform.rotation)as GameObject);
		ghost.transform.SetParent (transform.parent, false);
		ghost.GetComponent<Image> ().color = Color.clear;
		gameObject.transform.GetChild (1).gameObject.GetComponent<Image>().color = Color.clear;
		gameObject.transform.GetChild (0).gameObject.GetComponent<Text>().color = Color.clear;

		startPosition = transform.position;
		startParent = transform.parent;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		ghost.transform.position = eventData.position;

	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		int tempSlotIndex = gameObject.GetComponent<slotController> ().index;
		Debug.Log (tempSlotIndex);
		inventoryController.updateAmount (tempSlotIndex);
		inventoryController.updateSprite (tempSlotIndex);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		Destroy (ghost);

	}

	#endregion

	#region IDropHandler implementation

	public void OnDrop (PointerEventData data)
	{
		GameObject fromItem = data.pointerDrag;
		if (data.pointerDrag == null) return; // (will never happen)

		DragHandeler d = fromItem.GetComponent<DragHandeler>();
		if (d == null)
		{
			// means something unrelated to our system was dragged from.
			// for example, just an unrelated scrolling area, etc.
			// simply completely ignore these.
			return;
			// note, if very unusually you have more than one "system"
			// of UNCDraggable items on the same screen, be careful to
			// distinguish them! Example solution, check parents are same.
		}
		inventoryController.switchItems(fromItem.GetComponent<slotController>().index, gameObject.GetComponent<slotController>().index);
	}

	#endregion



}