using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	
	public int value = 0;
	public int runningCost = 0;
	public float radius = 1f;
	public Collider nearby;
	public LayerMask lookingFor;

	public GameObject homeBase;

	public virtual void Update(){
		StartCoroutine("BillPlayer");
	}

	IEnumerator BillPlayer(){
		Debug.Log("Pay'n da bills");
		homeBase.GetComponent<EconomySystem>().RemoveMoney(runningCost);
		yield return new WaitForSeconds(runningCost);
	}
	
}
