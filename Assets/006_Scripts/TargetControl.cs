using UnityEngine;
using System.Collections;

public class TargetControl: MonoBehaviour
{
	private Quaternion originRos;
	private Vector3 originScale;
	private Vector3 originPos;
	
	void Awake ()
	{
		originRos = transform.localRotation;
		originScale = transform.localScale;
		originPos = transform.localPosition;
	}
	
	public virtual void ResetObject ()
	{
		transform.localRotation = originRos;
		transform.localScale = originScale;
		transform.localPosition = originPos;

	}
	
	public virtual void InitObject ()
	{ 

	}
}
