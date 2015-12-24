using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float rotationRate = 1.0f;
	public bool rotateX = true;
	public bool rotateAroundSelf = false;
    private bool wasRotating;
    RaycastHit hit;
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Touch theTouch = Input.GetTouch(0);

            var ray = Camera.main.ScreenPointToRay(theTouch.position);

            if (Physics.Raycast(ray,out hit, Mathf.Infinity))
            {

                if (Input.touchCount == 1)
                {

                    if (theTouch.phase == TouchPhase.Began)
                    {
                        wasRotating = false;
                    }

                    if (theTouch.phase == TouchPhase.Moved)
                    {
                        float deltaY = theTouch.deltaPosition.y;
                        float deltaX = theTouch.deltaPosition.x;
                        float absY = Mathf.Abs(deltaY);
                        float absX = Mathf.Abs(deltaX);

						Space space;
						if(rotateAroundSelf){
							space = Space.Self;
						}else{
							space = Space.World;
						}

                        if (absY > absX)
                        {
							if(rotateX){
								if (deltaY > 0)
	                            {
									transform.Rotate(absY * rotationRate, 0, 0, space);
	                            }
	                            else
	                            {
									transform.Rotate(absY * rotationRate * -1, 0, 0, space);
	                            }
							}
                        }
						else 
                        {
							if (deltaX > 0)
							{
								transform.Rotate(0, absX * rotationRate * -1, 0, space);
							}
							else
							{
								transform.Rotate(0, absX * rotationRate, 0, space);
							}
                        }
                        wasRotating = true;
                    }
                }
            }
        }
    }
}
