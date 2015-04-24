using UnityEngine;
using System.Collections;

public class DefenseTower : Tower{

	Laser laser;

	void Start(){
		laser = GetComponent<Laser>();
	}
	
	public override void Update(){
		base.Update();
		if(FocusFound()){
			laser.Fire(nearby.gameObject);
			Debug.Log("Firing at enemies");					   
		}
	}
	
	bool FocusFound(){		
		if(Physics.CheckSphere(transform.position, radius, lookingFor.value)){
			Debug.Log("Target Aquired");
			nearby = Physics.OverlapSphere(transform.position, radius, lookingFor.value)[0];
			return true;		   
		}
		Debug.Log("Everything Looks Fine");
				return false;
	}
}	

