using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public float health;
	public float damage;   

	NavMeshAgent navAgent;
	public Vector3 target;
	public bool isNewTarget;

	public float radius = 1f;

	public Collider[] nearby;
	public LayerMask lookingFor;	
	
	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		nearbyEnemies = Physics.OverlapSphere(transform.position, radius, enemies);
		if(Physics.CheckSphere(transform.position, radius, enemies)){
			
			Destroy(nearbyEnemies[0].gameObject);
		}
		if(isNewTarget){
			navAgent.SetDestination(target);
		}
	}

	public void SetTarget(Vector3 newTarget){
		target = newTarget;
		isNewTarget = true;
	}
}
