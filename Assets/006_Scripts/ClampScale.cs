using UnityEngine;
using System.Collections;

public class ClampScale : MonoBehaviour {
	public float minScale = 0.5f;
	public float maxScale = 2.0f;

	// Update is called once per frame
	void LateUpdate () {
		float mag = Mathf.Clamp (transform.localScale.x, minScale, maxScale);
		transform.localScale = new Vector3(mag, mag, mag);
	}
}
