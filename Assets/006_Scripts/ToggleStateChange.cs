using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleStateChange : MonoBehaviour {
	void Start(){
		gameObject.GetComponent<Toggle> ().onValueChanged.AddListener (OnValueChange);
	}

	public void OnValueChange(bool isOn){
		if (!isOn) {
			iTween.ScaleTo (gameObject, iTween.Hash("scale", Vector3.one, "easeType", "easeOutBack", "time", 0.25f));
		} else {
			iTween.ScaleTo (gameObject, iTween.Hash("scale", new Vector3(1.5f, 1.5f, 1.5f), "easeType", "easeOutBack", "time", 0.25f));
		}
	}
}
