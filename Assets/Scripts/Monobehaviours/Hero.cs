using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	NavMeshAgent navAgent;
	public Vector3 target;
	public bool isNewTarget;

	public float radius = 1f;
	public Collider nearby;
	public LayerMask lookingFor;

	public virtual void Start () {
		navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		nearby = Physics.OverlapSphere(transform.position, radius, lookingFor)[0];
		if(Physics.CheckSphere(transform.position, radius, lookingFor)){
			
			Debug.Log("Hero: Target Aquired");
		}
		if(isNewTarget){
			navAgent.SetDestination(target);
			Debug.Log("Destination Set On My Way!");
		}
	}

	public void SetTarget(Vector3 newTarget){
		target = newTarget;
		isNewTarget = true;
	}
}
