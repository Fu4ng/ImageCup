using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour
{

	public float ZoomSpeed = 50;
	public float zoomSpeed
	{
		get
		{
			return ZoomSpeed;
		}
		set
		{
			ZoomSpeed = value;
		}
	}
	public float MaxY = 3921;
	public float maxY
	{
		get
		{
			return MaxY;
		}
		set
		{
			MaxY = value;
		}
	}

	public float MinY = 1200;
	public float minY
	{
		get
		{
			return MinY;
		}
		set
		{
			MinY = value;
		}
	}
	// Update is called once per frame
	private Vector2 lastTouchPos1 = Vector2.zero;
	private Vector2 lastTouchPos2 = Vector2.zero;


	void Update()
	{
		//这里是鼠标控制
		if (Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			var forward = Camera.main.transform.forward * ZoomSpeed * Input.GetAxis("Mouse ScrollWheel");
			Camera.main.transform.position += forward;
		}
		//这里是在手机上手势控制
		if (Input.touchCount > 1)
		{

			if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
			{
				Vector2 v1 = Input.GetTouch(0).position;
				Vector2 v2 = Input.GetTouch(1).position;



				float distance = Vector3.Distance(v1, v2);
				Vector3 forward = Camera.main.transform.forward * distance * Time.deltaTime * 0.5f;
				Vector3 newPos = Camera.main.transform.position + forward;
				if (newPos.y > MaxY || newPos.y < MinY)
				{

				}
				else
				{
					Camera.main.transform.position = newPos;
				}
				lastTouchPos1 = Input.GetTouch(0).position;
				lastTouchPos2 = Input.GetTouch(1).position;

			}
			else
			{
				lastTouchPos1 = Vector2.zero;
				lastTouchPos2 = Vector2.zero;
			}


		}

	}


	private float GetDistance(Vector2 pos1, Vector2 pos2)
	{
		if (lastTouchPos1 == Vector2.zero && lastTouchPos2 == Vector2.zero)
		{
			return 0.0f;
		}

		return (pos2 - pos1).sqrMagnitude - (lastTouchPos2 - lastTouchPos1).sqrMagnitude;
	}

}