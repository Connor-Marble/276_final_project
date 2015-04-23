using UnityEngine;
using System.Collections;

public class NavTest : MonoBehaviour {

	NavMeshAgent navAgent;

	public Transform target;
	Vector3 start;
	bool returning = false;

	private float goalDistance = 5f;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		navAgent.SetDestination (target.position);
		start = transform.position;
		InvokeRepeating ("CheckDestination", Random.value, 1f);
	}

	void CheckDestination(){
		if (navAgent.remainingDistance < goalDistance) {
			returning = !returning;
			navAgent.destination = returning?start:target.position;
		}
	}
}
