using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByFinger: MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//没有触摸的情况
		if (Input.touchCount == 0) {
			return;
		}

		if (Input.touchCount == 1) {
			Touch fingerPoint = Input.GetTouch (0);
			Vector2 deltations = fingerPoint.deltaPosition;
			transform.Rotate (Vector3.down * deltations.x, Space.World);
			transform.Rotate (Vector3.right * deltations.y, Space.World);

		}


	}
}
