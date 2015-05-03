using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour, IWeapon {

	[SerializeField]
	private float range=5f;
	
	[SerializeField]
	private GameObject rocketPrefab;
	
	[SerializeField]
	private Transform launcher;
	private float lastFire;
	[SerializeField]
	private float cooldown = 5f;
	// Use this for initialization
	void Start () {
		lastFire = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Interface
	
	public void Fire(GameObject target){
		GameObject rocket_go = (GameObject)Instantiate(rocketPrefab, launcher.position, launcher.rotation);
		rocket_go.transform.Rotate(transform.right*-90);
		Rocket rocket = rocket_go.GetComponent<Rocket>();
		rocket.target = target.transform;
		lastFire = Time.timeSinceLevelLoad;
	}
	
	public bool IsReady(){
		return lastFire+cooldown<Time.timeSinceLevelLoad;
	}
	
	public float GetRange(){
		return range;
	}
}
