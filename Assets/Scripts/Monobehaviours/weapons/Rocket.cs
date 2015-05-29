using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public Transform target;
	[SerializeField]
	private float explodeTime = 5f;

	private Rigidbody rbody;

	private float rotationSpeed = 0f;
	
	[SerializeField]
	private float damage = 15f;

	[SerializeField]
	private GameObject explosion;
	private bool exploding = false;

	// Use this for initialization
	void Start () {
		Invoke("explode", explodeTime);
		rbody = GetComponent<Rigidbody>();
		rbody.velocity = transform.forward*15f;

	}
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			Vector3 targetVector = target.position - transform.position;
			Quaternion targetRotation = Quaternion.LookRotation(targetVector, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
			rbody.velocity = transform.forward * rbody.velocity.magnitude;
		}
		rotationSpeed += Time.deltaTime*0.2f;
	}
	
	void OnCollisionEnter(Collision coll){
		explode();

		HealthSystem enemyHealth = target.gameObject.GetComponent<HealthSystem> ();
		if (enemyHealth != null) {
			enemyHealth.Damage (damage);
		}
		
	}
	
	void explode (){
		if(exploding)
			return;
			
		exploding = true;
		Destroy(gameObject, 1f);
		rbody.isKinematic = true;
		GetComponent<Renderer>().enabled = false;
		Instantiate (explosion, transform.position, Quaternion.identity);
	}
	
}
