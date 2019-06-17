using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bgImage;
	private Image joystickImage;

	public Vector3 InputDirection { set; get; }

	public virtual void OnDrag(PointerEventData data) {
		Vector2 pos = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
			bgImage.rectTransform,
			data.position,
			data.pressEventCamera,
			out pos
			)
		) {
			pos.x = pos.x / bgImage.rectTransform.sizeDelta.x;
			pos.y = pos.y / bgImage.rectTransform.sizeDelta.y;
			float x = (bgImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
			float y = (bgImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;
			InputDirection = new Vector3 (x, 0, y);
			if (InputDirection.magnitude > 1) {
				InputDirection = InputDirection.normalized;
			}
			x = InputDirection.x * bgImage.rectTransform.sizeDelta.x / 3;
			y = InputDirection.z * bgImage.rectTransform.sizeDelta.y / 3;
			joystickImage.rectTransform.anchoredPosition = new Vector3 (x, y);
		}
	}

	public virtual void OnPointerDown(PointerEventData data) {
		OnDrag (data);
	}

	public virtual void OnPointerUp(PointerEventData data) {
		InputDirection = Vector3.zero;
		joystickImage.rectTransform.anchoredPosition = Vector3.zero;
	}


	// Use this for initialization
	void Start () {
		bgImage = GetComponent<Image> ();
		joystickImage = transform.GetChild (0).GetComponent<Image> ();
		InputDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
