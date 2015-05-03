using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	
	public int value = 0;
	public int runningCost = 0;
	public float radius = 1f;
	public bool underConstruction = true;
	public GameObject scaffoldTower;
	public GameObject finalTower;
	
	public Collider nearby;
	public LayerMask lookingFor;

	public GameObject homeBase;

	public virtual void Start(){
		Instantiate(scaffoldTower, transform.position, transform.rotation);
	}
	
	public virtual void Update(){
		checkConstruction();
		if(underConstruction == false){
			Debug.Log(underConstruction);
			StartCoroutine("BillPlayer");
		}
	}

	IEnumerator BillPlayer(){	   
		homeBase.GetComponent<EconomySystem>().RemoveMoney(runningCost);
		yield return new WaitForSeconds(runningCost);
	}

	void checkConstruction(){
		if(gameObject.GetComponent<HealthSystem>().GetHealth() == 100f && underConstruction){
			underConstruction = false;
			Instantiate(finalTower, transform.position, transform.rotation);
		}
	}

	public void SetHomeBase(GameObject homeBase){
		this.homeBase = homeBase;
	}
}
