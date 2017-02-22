using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CastingBar : MonoBehaviour {

	private Vector2 startPos;
	private Vector2 endPos;

	public Image castImage;
	public bool casting;

	public RectTransform castTransform;
	// Use this for initialization
	void Start () {
		endPos = castTransform.anchoredPosition;
		startPos = new Vector2 (castTransform.anchoredPosition.x - castTransform.rect.width, castTransform.anchoredPosition.y);
		Debug.Log (castTransform.anchoredPosition);
		Debug.Log (startPos);
	}
	public void startCast(InventoryItem item) {
		casting = true;
		StartCoroutine (Cast (item));
	}
	
	// Update is called once per frame
	private IEnumerator Cast(InventoryItem item) {

		castTransform.anchoredPosition = startPos;

		float timeLeft = Time.deltaTime;
		float rate = 1.0f / item.castTime;
		float progress = 0.0f;
		while (progress <= 1.0 && casting) {
			castTransform.localPosition = Vector3.Lerp (startPos, endPos, progress);
			progress += rate * Time.deltaTime;
			timeLeft += Time.deltaTime;
			yield return null;

		}
		if (progress >= 1.0) {
			EventManager.TriggerEvent ("UseItem");
		}
		castTransform.position = endPos;

	}
}
