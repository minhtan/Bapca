using UnityEngine;
using System.Collections;
using UnityEditor;

public class RandomMovement : MonoBehaviour {
	[Range(1.0f, 20.0f)]
	public float speed = 5.0f;

	[Range(1.0f, 50.0f)]
	public float displacement = 10.0f;

	bool isCouRunning = false;

	// Update is called once per frame
	void Update () {
		if(!isCouRunning){
			MoveMeRandomly ();
		}
	}

	void MoveMeRandomly(){
		Vector3 vel;

		vel = Random.insideUnitSphere * displacement;
		vel.z = 0.0f;
		vel.x = 0.0f;

		StartCoroutine (MoveTo(vel));
	}

	IEnumerator MoveTo(Vector3 destination){
		isCouRunning = true;
		do{
			float step = speed * Time.deltaTime;
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, step);
			yield return null;
		}while(Vector3.Distance(transform.localPosition, destination) > 0.001f);
		isCouRunning = false;
	}

}
