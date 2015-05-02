using UnityEngine;
using System.Collections;

public class EconTower : Tower{
	
	public int profit = 0;
	public float profitRate = 1f;
	bool canProfit = true;
	

	public override void Start(){
		base.Start();
	}
   
	public override void Update(){
		base.Update();
		StartCoroutine("Profit");
	}

	IEnumerator Profit(){
		if(!underConstruction && canProfit){
			homeBase.GetComponent<EconomySystem>().AddMoney(profit);
			canProfit = false;
			yield return new WaitForSeconds(profitRate);
			canProfit = true;
		}
	}
}
