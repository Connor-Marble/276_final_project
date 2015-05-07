using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineerUI : MonoBehaviour{
	[SerializeField]
	private GameObject engineerCreateMenu;
	private GameObject selectedUnit;	

	void Start(){
		HideUI();		
	}

	public void HideUI(){
		engineerCreateMenu.SetActive(false);
	}

	public void ShowUI(){
		engineerCreateMenu.SetActive(true);
	}
}