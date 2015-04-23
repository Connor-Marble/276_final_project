using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float dragSpeed = 100f;
	public float zoomSpeed = 100f;
	public float maxYZoom = 100f;
	public float minYZoom = 10f;
	public float maxXPan = 18;
	public float minXPan = -54;
	public float maxZPan = 300;
	public float minZPan = 100;
	public float minAngle = 20;
	public float maxAngle = 45;
	
	float zoom;
	float yZoom;

    void Update(){
		zoom = Input.GetAxis("Mouse ScrollWheel");

		if(zoom != 0){
			Zoom();
		}

		if(Input.GetMouseButton(2)){
			Debug.Log("Middle Mouse button pressed");
			Translate();
		}
	}

	void Zoom(){
		Vector3 localPos = transform.localPosition;
		// zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
		yZoom = Mathf.Clamp(localPos.y + zoom, minYZoom, maxYZoom);

		Vector3 cameraTo = new Vector3 (localPos.x,
										localPos.y + zoom * zoomSpeed,
										localPos.z);

		float angle = Mathf.Clamp(transform.eulerAngles.x + zoom, minAngle, maxAngle);
		
		transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
		transform.position = new Vector3( cameraTo.x, yZoom, cameraTo.z);
		
		Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
	}

	void Translate(){
		Debug.Log("Translate started");
		Vector3 translation = Vector3.zero;

		float xPan = translation.x - Input.GetAxis("Mouse X") * -dragSpeed *Time.deltaTime;
		float zPan = translation.z - Input.GetAxis("Mouse Y")* -dragSpeed * Time.deltaTime;
		// translation -= new Vector3(xPan,0,zPan);

		transform.position = new Vector3(Mathf.Clamp(transform.position.x + xPan, minXPan, maxXPan),
										 transform.position.y,
										 Mathf.Clamp(transform.position.z + zPan, minZPan, maxZPan));
	}
}