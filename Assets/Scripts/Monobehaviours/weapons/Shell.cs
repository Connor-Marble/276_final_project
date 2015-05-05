using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {
	[SerializeField]
	private float height = 10f;
	public Vector3 target;
	private Rigidbody rbody;
	
	[SerializeField]
	private float aimError = 0.5f;
	// Use this for initialization
	[SerializeField]
	private GameObject explosion;
	void Start () {
		rbody = GetComponent<Rigidbody>();
		float fallTime = 2*height/Physics.gravity.magnitude;
		Vector3 lateral = target-transform.position;
		rbody.velocity = new Vector3(lateral.x/fallTime, height, lateral.z/fallTime);
		rbody.velocity += Random.insideUnitSphere*aimError;
	}
	
	void OnCollisionEnter(){
		Explode();
	}
	
	void Explode(){
		Renderer rend = GetComponent<Renderer>();
		rend.enabled =false;
		rbody.isKinematic = true;
		Destroy(gameObject, 2f);
		Instantiate(explosion, transform.position, Quaternion.identity);	
	}
}
