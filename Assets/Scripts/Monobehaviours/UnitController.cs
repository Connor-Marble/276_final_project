using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour{

	public LayerMask playerUnits;
	public LayerMask terrainLayer;
	public bool unitSelected = false;
	public bool createTower = false;
	public GameObject homeBase;

	RaycastHit unitHitInfo = new RaycastHit();
	RaycastHit terrainHitInfo = new RaycastHit();
	Vector3 towerLoc;

	public GameObject econTower;
	public GameObject i_tower;

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("Left Click");
			SelectUnit();			
		}

		if(Input.GetMouseButtonDown(1) && unitSelected){			
			Debug.Log("Right Click");			
			MoveUnit();
			if(createTower){
				towerLoc = new Vector3(terrainHitInfo.point.x, 2.5f, terrainHitInfo.point.z);
				BuildTower(econTower);	
			}
		}
 	}

	void SelectUnit(){
		bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
								   out unitHitInfo,
								   Mathf.Infinity,
								   playerUnits.value);
	    unitSelected = hit ? true : false;
	}

	void MoveUnit(){
		bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
								   out terrainHitInfo,
								   Mathf.Infinity,
								   terrainLayer.value);
		if(hit){
			Debug.Log("Unit hit and target set");			
			unitHitInfo.transform.gameObject.GetComponent<Hero>().SetTarget(terrainHitInfo.point);
		}
	}

	void BuildTower(GameObject tower){
		GameObject newTower = (GameObject)Instantiate(tower, towerLoc, Quaternion.identity);
		newTower.GetComponent<Tower>().SetHomeBase(homeBase);
		Debug.Log("Building Tower");
	}
}