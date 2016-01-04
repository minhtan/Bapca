using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleStateChange : MonoBehaviour {
	public float scale = 1.4f;
	public AutoRotate autoRotate;
	public GameObject pnlInfo;

	void Start(){
		gameObject.GetComponent<Toggle> ().onValueChanged.AddListener (OnValueChange);
	}

	public void OnValueChange(bool isOn){
		if (!isOn) {
			iTween.ScaleTo (gameObject, iTween.Hash("scale", Vector3.one, "easeType", "easeOutBack", "time", 0.25f));
			if(autoRotate != null){
				autoRotate.enabled = false;
			}
			if(pnlInfo != null){
				iTween.ScaleTo (pnlInfo, iTween.Hash("scale", Vector3.zero, "easeType", "easeInCirc", "time", 0.25f));
			}
		} else {
			iTween.ScaleTo (gameObject, iTween.Hash("scale", new Vector3(scale, scale, scale), "easeType", "easeOutBack", "time", 0.25f));
			if(autoRotate != null){
				autoRotate.enabled = true;
			}
			if(pnlInfo != null){
				iTween.ScaleTo (pnlInfo, iTween.Hash("scale", Vector3.one, "easeType", "easeOutCirc", "time", 0.25f));			
			}
		}
	}

	public void _CloseInfo(){
		gameObject.GetComponent<Toggle> ().isOn = false;
	}
}
