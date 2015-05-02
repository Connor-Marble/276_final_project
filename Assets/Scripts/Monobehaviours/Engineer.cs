using UnityEngine;
using System.Collections;

public class Engineer : Hero {	

	float buildRate = 1f;

	// Use this for initialization
	public override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
		if(nearby != null && nearby.GetComponent<HealthSystem>().GetHealth() < 100f){
			StartCoroutine("Heal");			
		}
	}

	float CalculateBuildTime(int cost){
		return ((float)cost/buildRate);
	}

	IEnumerator Heal(){
		if(nearby.GetComponent<HealthSystem>().GetHealth() == 1f){
			nearby.GetComponent<HealthSystem>().IncreaseHealth(99f);
		}
		nearby.GetComponent<HealthSystem>().Heal(1f);
		yield return new WaitForSeconds(buildRate);		
	}
}
