using UnityEngine;
using System.Collections;
using Vuforia;

public class MyTrackableHandler : MonoBehaviour,
                                                ITrackableEventHandler
{
	#region PRIVATE_MEMBER_VARIABLES

	private TrackableBehaviour mTrackableBehaviour;

	private TargetControl targetControl;

	#endregion // PRIVATE_MEMBER_VARIABLES

	#region UNITY_MONOBEHAVIOUR_METHODS

	void Start ()
	{

		targetControl = GetComponentInChildren<TargetControl> ();

		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
	}

	#endregion // UNITY_MONOBEHAVIOUR_METHODS



	#region PUBLIC_METHODS

	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged (
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			OnTrackingFound ();
		} else {
			OnTrackingLost ();
		}
	}

	#endregion // PUBLIC_METHODS

	#region PRIVATE_METHODS

	private void OnTrackingFound ()
	{
		foreach(Transform t in transform){
			t.gameObject.SetActive(true);
		}	
		if (targetControl != null) {
			targetControl.InitObject ();
		}
	}

	private void OnTrackingLost ()
	{
		if (targetControl != null) {
			targetControl.ResetObject ();
		}
		foreach(Transform t in transform){
			t.gameObject.SetActive(false);
		}
	}

	#endregion // PRIVATE_METHODS

}