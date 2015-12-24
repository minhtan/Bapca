using UnityEngine;
using System.Collections;

public class iTweenWorldZoomToCanvas : MonoBehaviour {

	public GameObject _WorldObject;
	//public RectTransform _UI_Element;
	public Canvas _Canvas;
	
	public void ZoomTo(){
		if(gameObject.transform.localScale.magnitude == Vector3.zero.magnitude){
		
			iTween.Stop ();

			RectTransform CanvasRect = _Canvas.GetComponent<RectTransform>();
			Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(_WorldObject.transform.position);
			Vector2 WorldObject_ScreenPosition = new Vector2(
				((ViewportPosition.x*CanvasRect.sizeDelta.x)-(CanvasRect.sizeDelta.x*0.5f)),
				((ViewportPosition.y*CanvasRect.sizeDelta.y)-(CanvasRect.sizeDelta.y*0.5f))
			);
			
			//now you can set the position of the ui element
			//gameObject.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
			
			iTween.MoveFrom (gameObject, iTween.Hash("x", WorldObject_ScreenPosition.x, 
			                                         "y", WorldObject_ScreenPosition.y, 
			                                         "easeType", "easeOutBack", 
			                                         "time", 0.75f));
			iTween.ScaleTo (gameObject, iTween.Hash("scale", Vector3.one, "easeType", "easeOutBack", "time", 0.75f));
		}
	}

	public void CloseMe(){
		transform.localScale = Vector3.zero;
	}

}
