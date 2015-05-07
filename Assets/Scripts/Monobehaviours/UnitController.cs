using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour{

	public LayerMask playerUnits;
	public LayerMask terrainLayer;
	public bool unitSelected = false;
	public bool createUnit = false;
	[SerializeField]
	private bool isUsingUI = false;
	public GameObject homeBase;

	public RaycastHit unitHitInfo = new RaycastHit();
	RaycastHit terrainHitInfo = new RaycastHit();
	Vector3 towerLoc;

	public GameObject constructionProject;

	void Update(){
		if(Input.GetMouseButtonDown(0) && !isUsingUI){
			Debug.Log("Left Click");
			SelectUnit();
		}

		if(!unitSelected){
			GetComponent<EngineerUI>().HideUI();
		}

		if(Input.GetMouseButtonDown(1) && unitSelected){			
			Debug.Log("Right Click");			
			MoveUnit();
			if(createUnit){
				towerLoc = new Vector3(terrainHitInfo.point.x, .15f, terrainHitInfo.point.z);
				BuildTower(constructionProject);
			}
		}
 	}

	void SelectUnit(){
		bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
								   out unitHitInfo,
								   Mathf.Infinity,
								   playerUnits.value);
	    unitSelected = hit ? true : false;
		if(unitSelected){
			GetComponent<EngineerUI>().ShowUI();
		}
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

	public void SetBuildContext(GameObject constructionProject){
		createUnit = true;
		this.constructionProject = constructionProject;
	}

	public void SetIsUsingUI(bool isUsingUI){
		this.isUsingUI = isUsingUI;
	}
}