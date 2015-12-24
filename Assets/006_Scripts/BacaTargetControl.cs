using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BacaTargetControl : TargetControl {

	public GameObject[] vegetables;
	public GameObject pnlInfo;
	public GameObject canvas;
	public Toggle[] toggles;

	#region MONO
	void Start () {

	}

	void Update () {
	
	}
	#endregion

	public override void InitObject ()
	{
		base.InitObject ();
		vegetables[1].SetActive(true);
		canvas.SetActive (true);
	}

	public override void ResetObject ()
	{
		ResetWithoutVegetables ();
		HideVegetables ();
		ResetToggles ();
		canvas.SetActive (false);
	}

	public void ResetWithoutVegetables(){
		base.ResetObject ();
		HideDetails ();
	}

	#region additions methods
	private void ResetToggles(){
		toggles [1].isOn = true;
	}

	private void HideVegetables(){
		for(int i = 0; i < vegetables.Length; i++){
			vegetables[i].SetActive(false);
		}
	}

	private void HideDetails(){
		foreach(Transform t in pnlInfo.transform){
			t.localScale = Vector3.zero;
		}
	}

	public void ShowDetail(iTweenWorldZoomToCanvas go){
		HideDetails ();
		go.ZoomTo ();
	}

	public void SelectVegetable(int index){
		for (int i = 0; i < vegetables.Length; i++) {
			vegetables[i].SetActive(false);
		}
		vegetables[index].SetActive(true);
		ResetWithoutVegetables();
	}
	#endregion

	public void OpenURL(string url){
		Application.OpenURL (url);
	}
}
