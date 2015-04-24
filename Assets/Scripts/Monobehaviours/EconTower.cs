using UnityEngine;
using System.Collections;

public class EconTower : Tower{
	
	public int profit = 0;
	public float profitRate = 1f;

	void Start(){
		nearby = Physics.OverlapSphere(transform.position, radius, lookingFor.value)[0];
	}
   
	public override void Update(){
		base.Update();
		StartCoroutine("Profit");
	}

	IEnumerator Profit(){
		Debug.Log("Dolla Dolla Bill Yall!");
		homeBase.GetComponent<EconomySystem>().AddMoney(profit);		

		yield return new WaitForSeconds(profitRate);
	}
}
