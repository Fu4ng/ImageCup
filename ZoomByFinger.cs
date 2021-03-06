using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomByFinger : MonoBehaviour {
	//In Camera 
	public GameObject EasyAR_Starup;
	public float CameraSpeed = 50;
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	private Vector2 LastTouchPostion1=Vector2.zero;
	private Vector2 LastTouchPostion2=Vector2.zero;
	void Update () {
		if (Input.touchCount > 1) {
			if (Input.GetTouch (0).phase == TouchPhase.Moved || Input.GetTouch (1).phase == TouchPhase.Moved) {
				Vector2 oldpostion1 = Input.GetTouch (0).position;
				Vector2 oldpostion2 = Input.GetTouch (1).position;

				float deltaPostion = (oldpostion1 - oldpostion2).sqrMagnitude - (LastTouchPostion1-LastTouchPostion2).sqrMagnitude;
				Vector3 forward = EasyAR_Starup.transform.forward * deltaPostion * Time.deltaTime * 0.5f;
				EasyAR_Starup.transform.position += forward;
				LastTouchPostion1 = Input.GetTouch (0).position;
				LastTouchPostion2 = Input.GetTouch (1).position;

			}
		} else 
		{
			LastTouchPostion1 = Vector2.zero;
			LastTouchPostion2 = Vector2.zero;
		}
	}
}
