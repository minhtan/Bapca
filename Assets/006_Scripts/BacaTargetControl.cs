using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BacaTargetControl : TargetControl {

	public GameObject[] vegetables;
	public GameObject pnlInfo;
	public GameObject canvas;
	public Toggle toggle;
	public ToggleGroup toggleGroupUI;

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
		SwitchOffToggleGroupUI ();
		base.ResetObject ();
		HideDetails ();
	}

	#region additions methods
	private void SwitchOffToggleGroupUI(){
		toggleGroupUI.SetAllTogglesOff ();
	}

	private void ResetToggles(){
		toggle.isOn = true;
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
			if(vegetables[i].activeSelf){
				vegetables[i].SetActive(false);
			}
		}
		vegetables[index].SetActive(true);
		ResetWithoutVegetables();
	}
	#endregion

	public void OpenURL(string url){
		Application.OpenURL (url);
	}
}
