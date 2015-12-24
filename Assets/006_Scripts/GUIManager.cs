using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	#region Singleton
	private static BacaTargetControl instance;
	
	public static BacaTargetControl Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<BacaTargetControl> ();
			}
			return instance;
		}
	}
	#endregion

	#region MONO
	void Start () {
	
	}

	void Update () {
	
	}
	#endregion MONO
}
