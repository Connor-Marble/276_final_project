using UnityEngine;
using System.Collections;

public class EconTower : MonoBehaviour{

	public float value;
	public float profitRate = 1f;
	public int profit = 0;
	public int runningCost = 0;

	public GameObject homeBase;

	float distance;

	void Start(){
		distance = Mathf.Abs((transform.position - homeBase.GetComponent<Transform>().position).magnitude);

		profit += (int)distance;
	}

	void Update(){
		StartCoroutine("FigureMoney");
	}

	IEnumerator FigureMoney(){
		Debug.Log("Dolla Dolla Bill Yall!");
		homeBase.GetComponent<EconomySystem>().AddMoney(profit);
		homeBase.GetComponent<EconomySystem>().RemoveMoney(runningCost);

		yield return new WaitForSeconds(profitRate);
	}
}
