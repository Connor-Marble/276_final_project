using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour{

	public LayerMask playerUnits;
	public LayerMask terrainLayer;
	public bool unitSelected = false;
	public Transform foo;

	RaycastHit unitHitInfo = new RaycastHit();
	RaycastHit terrainHitInfo = new RaycastHit();

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("Left Click");
			SelectUnit();
		}

		if(Input.GetMouseButtonDown(1) && unitSelected){
			Debug.Log("Right Click");
			MoveUnit();
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
}