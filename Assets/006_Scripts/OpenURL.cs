using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenURL : MonoBehaviour {

	public void _OpenURL(){
		Application.OpenURL(gameObject.GetComponent<Text>().text);
	}
}
