using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{	
	public GameObject _WorldObject;
	public RectTransform _UI_Element;
	public Canvas _Canvas;

	void Start(){
		//iTween.RotateFrom(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "delay", .4));

		RectTransform CanvasRect = _Canvas.GetComponent<RectTransform>();
		Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(_WorldObject.transform.position);
		Vector2 WorldObject_ScreenPosition = new Vector2(
			((ViewportPosition.x*CanvasRect.sizeDelta.x)-(CanvasRect.sizeDelta.x*0.5f)),
			((ViewportPosition.y*CanvasRect.sizeDelta.y)-(CanvasRect.sizeDelta.y*0.5f))
		);
		
		//now you can set the position of the ui element
		//_UI_Element.anchoredPosition = WorldObject_ScreenPosition;

		iTween.MoveFrom (gameObject, iTween.Hash("x", WorldObject_ScreenPosition.x, "y", WorldObject_ScreenPosition.y, "easeType", "easeInOutQuint", "time", 1.0f));
		iTween.ScaleTo (gameObject, iTween.Hash("scale", Vector3.one, "easeType", "easeInOutQuint", "time", 1.0f));
	}
}

