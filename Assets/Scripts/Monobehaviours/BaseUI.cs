using UnityEngine;
using System.Collections;

public class BaseUI : MonoBehaviour {

	[SerializeField]
	private GameObject unitCreateMenu;


	UnitSpawner spawner;

	// Use this for initialization
	void Start () {
		spawner = GetComponent<UnitSpawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		unitCreateMenu.SetActive (true);
	}

	public void HideUI(){

	}
}
