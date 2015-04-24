using UnityEngine;
using System.Collections;

[RequireComponent (typeof(HealthSystem))]
public class UnitBase : MonoBehaviour {

	[SerializeField]
	private LayerMask targetLayer;

	[SerializeField]
	private Transform finalGoal;

	UnitBase target;

	[SerializeField]
	float attackRange = 5f;

	[SerializeField]
	float weapnPower;

	NavMeshAgent navAgent;


	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		navAgent.destination = finalGoal.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			if(GetTarget()){
				navAgent.Stop();
				navAgent.destination = transform.position;
			}
			else{
				navAgent.Resume();
				navAgent.destination = finalGoal.position;
			}
		}

		if (target != null) {
			float distance = GetDistancetoTarget ();
			if (distance < attackRange)
				Attack ();

			else {
				target = null;
				return;
			}
		}
	}

	bool GetTarget () {
		Collider[] potentialEnemies = Physics.OverlapSphere (transform.position, attackRange, targetLayer);
		foreach (Collider coll in potentialEnemies) {
			UnitBase enemyunit = coll.gameObject.GetComponent<UnitBase>();
			if(enemyunit != null){

				target = enemyunit;
				return true;
			}
		}

		return false;
	}

	float GetDistancetoTarget(){
		return Vector3.Distance (transform.position, target.gameObject.transform.position);
	}

	void Attack(){
		HealthSystem enemyHealth = target.GetComponent<HealthSystem> ();
		enemyHealth.Damage (weapnPower);
		Debug.DrawLine (transform.position, target.transform.position, Color.red);
	}
}
