using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float dragSpeed = 100f;
	public float zoomSpeed = 100f;
	public float maxYZoom = 100f;
	public float minYZoom = 10f;
	public float maxXPan = 18;
	public float minXPan = -54;
	public float maxZPan = 230;
	public float minZPan = -100;
	public float minAngle = 20;
	public float maxAngle = 45;
	
	float zoom;
	float yZoom;

	private Quaternion lowAngle;
	private Quaternion highAngle;

	void Start() {
		lowAngle = new Quaternion (0, -1, 0, 0);
		highAngle = new Quaternion (0, -1, 1, 0);
		Zoom();
	}

    void Update(){
		zoom = Input.GetAxis("Mouse ScrollWheel");

		if(zoom != 0){
			Zoom();
		}

		if(Input.GetMouseButton(2)){
			Translate();
		}


	}

	void Zoom(){
		Vector3 localPos = transform.localPosition;
		// zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
		yZoom = Mathf.Clamp(localPos.y + zoom * zoomSpeed, minYZoom, maxYZoom) ;

		Vector3 cameraTo = new Vector3 (localPos.x,
										localPos.y + zoom * zoomSpeed,
										localPos.z);

		float zoomRatio = (yZoom - minYZoom) / (maxYZoom - minYZoom);
		float angleZoom = (zoomRatio)*((maxAngle-minAngle)/90) + (minAngle/90);
		transform.rotation = Quaternion.Slerp(lowAngle, highAngle, angleZoom);

		transform.position = new Vector3( cameraTo.x, yZoom, cameraTo.z);
				
	}

	void Translate(){
		Vector3 translation = Vector3.zero;

		float xPan = translation.x - Input.GetAxis("Mouse X") * -dragSpeed *Time.deltaTime;
		float zPan = translation.z - Input.GetAxis("Mouse Y")* -dragSpeed * Time.deltaTime;
		// translation -= new Vector3(xPan,0,zPan);

		transform.position = new Vector3(Mathf.Clamp(transform.position.x + xPan, minXPan, maxXPan),
										 transform.position.y,
										 Mathf.Clamp(transform.position.z + zPan, minZPan, maxZPan));
	}
}