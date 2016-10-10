using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image joystick_bg;
	private Image Joystick_nob;
	private Vector3 inputVector;

	private void Start() {
		joystick_bg = GetComponent<Image> ();
		Joystick_nob = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped) {
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick_bg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / joystick_bg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / joystick_bg.rectTransform.sizeDelta.y);
			inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
			Debug.Log (inputVector);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			Joystick_nob.rectTransform.anchoredPosition = new Vector3(inputVector.x * (joystick_bg.rectTransform.sizeDelta.x / 3),
				inputVector.z * (joystick_bg.rectTransform.sizeDelta.y /3));
		}
		

	}
	public virtual void OnPointerDown(PointerEventData ped) {
		OnDrag (ped);
	}
	public virtual void OnPointerUp(PointerEventData ped) {
		inputVector = Vector3.zero;
		Joystick_nob.rectTransform.anchoredPosition = Vector3.zero;
	}
	public float Horizontal() {
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}
	public float Vertical() {
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");	
	}
}
