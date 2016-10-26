using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShopSlotHandler : MonoBehaviour, IPointerClickHandler
{
	public ShopUIController shopUIController;
	public int index;

	public void OnPointerClick(PointerEventData eventData){
		Debug.Log (eventData);
		shopUIController.purchaseItem (index);
	}
	//code for double click
//	int tap;
//	float interval = 0.5f;
//	bool readyForDoubleTap;
//	public void OnPointerClick(PointerEventData eventData)
//	{
//		tap ++;
//
//		if (tap ==1)
//		{
//			//do stuff
//
//			StartCoroutine(DoubleTapInterval() );
//		}
//
//		else if (tap>1 && readyForDoubleTap)
//		{
//			//do stuff
//
//
//			tap = 0;
//			readyForDoubleTap = false;
//		}
//	}
//
//	IEnumerator DoubleTapInterval()
//	{  
//		yield return new WaitForSeconds(interval);
//		readyForDoubleTap = true;
//	}
}