using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VegetableInfo : MonoBehaviour {

	[System.Serializable]
	public class VegetableInfoDetail : System.Object{
		public Text textField;
		public string info;
	}
	public VegetableInfoDetail[] infos;


	void Start(){
		gameObject.GetComponent<Toggle> ().onValueChanged.AddListener (OnValueChange);
	}

	void OnValueChange (bool isOn)
	{
		if (isOn) {
			foreach(VegetableInfoDetail vi in infos){
				vi.textField.text = vi.info;
			}
		}
	}
}
