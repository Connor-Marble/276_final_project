using UnityEngine;
using System.Collections;

public class SplashDamage : MonoBehaviour {
	[SerializeField]
	private LayerMask mask;
	[SerializeField]
	private float cutOff = 5f;


	[SerializeField]
	private float damageMult;
	// Use this for initialization
	void Start () {
		Collider[] colliders = Physics.OverlapSphere(transform.position, cutOff, mask);
		foreach(Collider coll in colliders){
			HealthSystem health = coll.gameObject.GetComponent<HealthSystem>();
			
			if(health!=null){
				float distance = Vector3.Distance(transform.position, coll.transform.position);
				float damage = (cutOff - distance) * damageMult;
				health.Damage(damage);
			}
		}
		Destroy(gameObject, 2f);
	}
	
}
