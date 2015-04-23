using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public float damage;
	public float value;
	
	public float radius = 1f;
	
	public Collider[] nearbyEnemies;
	public LayerMask enemies;

	LineRenderer line;
	
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer>();
		line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		nearbyEnemies = Physics.OverlapSphere(transform.position, radius, enemies);

		if(Physics.CheckSphere(transform.position, radius, enemies)){
			Attack();
		}
	}

	void Attack(){
		nearbyEnemies[0].GetComponent<HealthSystem>().Damage(damage);

		line.enabled = true;

		line.SetPosition(0, transform.GetChild(0).GetComponent<Transform>().position);
		line.SetPosition(1, nearbyEnemies[0].GetComponent<Transform>().position);
	}
}
