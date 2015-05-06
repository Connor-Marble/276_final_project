using UnityEngine;
using System.Collections;

[RequireComponent (typeof(HealthSystem))]
[RequireComponent (typeof(IWeapon))]
public class UnitBase : MonoBehaviour {

	[SerializeField]
	private LayerMask targetLayer;

	[SerializeField]
	private Transform finalGoal;
	private Transform startGoal;
	private Transform currentGoal;

	public string startGoalName;
	[SerializeField]
	private string endGoalName;
	GameObject target;

	IWeapon weapon;

	NavMeshAgent navAgent;


	// Use this for initialization
	void Start () {

		if (finalGoal == null)
			finalGoal = GameObject.Find (endGoalName).transform;
			
		if(startGoal == null)
			startGoal = GameObject.Find(startGoalName).transform;

		currentGoal = startGoal;
		navAgent = GetComponent<NavMeshAgent> ();
		navAgent.destination = currentGoal.position;
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
				navAgent.destination = currentGoal.position;
			}
		}

		if (target != null) {
			float distance = GetDistancetoTarget ();
			if (distance < weapon.GetRange() && weapon.IsReady())
				weapon.Fire(target);

			else {
				target = null;
				return;
			}
		}
		updateGoal();
	}
	
	void updateGoal(){
		if(Vector3.Distance(transform.position, startGoal.position)<10f){
			currentGoal = finalGoal;
		}
	}

	bool GetTarget () {
		Collider[] potentialEnemies = Physics.OverlapSphere (transform.position, weapon.GetRange(), targetLayer);
		if (potentialEnemies == null)
			return false;

		foreach (Collider coll in potentialEnemies) {
			HealthSystem enemyHealth = coll.gameObject.GetComponent<HealthSystem>();
			if(enemyHealth != null && Vector3.Distance(transform.position, coll.transform.position)<weapon.GetRange()){

				target = coll.gameObject;
				return true;
			}
		}

		return false;
	}

	float GetDistancetoTarget(){
		return Vector3.Distance (transform.position, target.transform.position)-5f;
	}

}
