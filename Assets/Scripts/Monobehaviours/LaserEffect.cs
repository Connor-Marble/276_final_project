using UnityEngine;
using System.Collections;

public class LaserEffect : MonoBehaviour {

	public Vector3 origin;
	public Vector3 target;

	// Use this for initialization
	void Start () {
		LineRenderer line = GetComponent<LineRenderer> ();
		line.SetPosition (0, origin);
		line.SetPosition (1, target);
		RaycastHit rayhit;
		if(Physics.Raycast(origin, target - origin, out rayhit, 100f)){
			transform.position = rayhit.point;			
		}
		Destroy (gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
