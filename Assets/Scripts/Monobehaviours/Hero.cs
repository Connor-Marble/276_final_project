using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	protected NavMeshAgent navAgent;
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
		if(Look()){
			nearby = Physics.OverlapSphere(transform.position, radius, lookingFor)[0];			
		}
		if(isNewTarget){
			navAgent.Resume();
			navAgent.SetDestination(target);
		}
		if(target == transform.position){
			navAgent.Stop();
		}

		
	}

	public void SetTarget(Vector3 newTarget){
		target = newTarget;
		isNewTarget = true;
	}

	bool Look(){
		if(Physics.CheckSphere(transform.position, radius, lookingFor.value)){
			return true;
		}
		return false;
	}
}
