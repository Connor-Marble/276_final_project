using UnityEngine;
using System.Collections;

[RequireComponent (typeof(HealthSystem))]
[RequireComponent (typeof(IWeapon))]
public class UnitBase : MonoBehaviour {

	[SerializeField]
	private LayerMask targetLayer;

	[SerializeField]
	private Transform finalGoal;

	UnitBase target;

	IWeapon weapon;

	NavMeshAgent navAgent;


	// Use this for initialization
	void Start () {

		if (finalGoal == null)
			finalGoal = GameObject.Find ("Enemy").transform;

		navAgent = GetComponent<NavMeshAgent> ();
		navAgent.destination = finalGoal.position;
		weapon = GetComponent<IWeapon> ();


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
			if (distance < weapon.GetRange() && weapon.IsReady())
				weapon.Fire(target.gameObject);

			else {
				target = null;
				return;
			}
		}
	}

	bool GetTarget () {
		Collider[] potentialEnemies = Physics.OverlapSphere (transform.position, weapon.GetRange(), targetLayer);
		if (potentialEnemies == null)
			return false;

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

}
