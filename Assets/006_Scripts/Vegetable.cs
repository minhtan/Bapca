﻿using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class Vegetable : MonoBehaviour {
	public LayerMask myLayerMask;
	public iTweenWorldZoomToCanvas myTween;
	private bool clicked;
	private float time;

	void OnEnable(){
		iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "z", 1, "easeType", "easeOutBounce"));
	}
	void OnDisable(){
		transform.localScale = Vector3.zero;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray m_Ray;
			m_Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit m_RayCastHit;
			if (Physics.Raycast(m_Ray.origin, m_Ray.direction, out m_RayCastHit, Mathf.Infinity, myLayerMask))
			{
				Debug.Log ("Raycasted" + m_RayCastHit.collider.name);
				if (m_RayCastHit.collider.tag == gameObject.tag)
				{
					Debug.Log(m_RayCastHit.collider.name);
					clicked = true;
					time = Time.time;
				}
			}
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			time = Time.time - time;
			if (clicked = true && time < 0.2f)
			{
				Ray m_Ray;
				m_Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit m_RayCastHit;
				if (Physics.Raycast(m_Ray.origin, m_Ray.direction, out m_RayCastHit, Mathf.Infinity, myLayerMask))
				{
					if (clicked = true && m_RayCastHit.collider.tag == gameObject.tag)
					{
						Debug.Log(m_RayCastHit.collider.name);
						myTween.ZoomTo();
						clicked = false;
					}
				}
			}
		}
	}
}