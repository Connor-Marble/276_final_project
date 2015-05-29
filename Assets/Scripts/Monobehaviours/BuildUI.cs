using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour {

	[SerializeField]
	private GameObject unitCreateMenu;
	[SerializeField]
	private GameObject unitButtonPrefab;
	int lane = -1;

	private GameObject unitButtons;

	UnitSpawner spawner;

	private Button[] buildButtons;
	private Text[] buildCounts;
	
	EconomySystem econ;

	// Use this for initialization
	void Start () {
		spawner = GetComponent<UnitSpawner> ();
		createUnitButtons (Vector2.one*spawner.GetUnitTypes().Length, 20f);
		HideUI ();
		econ = GetComponent<EconomySystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		ShowUI ();
	}

	public void setLane(int value){
		lane = value;
		unitButtons.SetActive (value >= 0);
		if (value >= 0)
			spawner.setActiveLane (value);
	}

	public void HideUI(){
		unitCreateMenu.SetActive (false);
		setLane (-1);
	}

	public void ShowUI(){
		unitCreateMenu.SetActive (true);
	}

	private void createUnitButtons(Vector2 size, float yOffset){
		UnitType[] types = spawner.GetUnitTypes ();
		GameObject parentObject = new GameObject ();
		
		//create button for each unit type
		for (int i =0; i<types.Length; i++) {
			//create button
			GameObject buildButton = Instantiate(unitButtonPrefab);
			RectTransform buttonTrans = buildButton.GetComponent<RectTransform>();
			
			//set position
			buildButton.transform.position = new Vector2(
					Mathf.Lerp(-size.x*buttonTrans.sizeDelta.x/2 + Screen.width/2, 
			        size.x*buttonTrans.sizeDelta.x/2 + Screen.width/2,
			        ((float)i)/((float)types.Length)),
					yOffset + buttonTrans.sizeDelta.y);
			
			buttonTrans.position += (Vector3)Vector2.right*buttonTrans.sizeDelta.x/2;
			
			//set partent to menu parent
			buildButton.transform.SetParent(parentObject.transform);

			//buttonTrans.localScale = size/types.Length;
			
			//set the text content of the button's various text children
			Text nameText = buildButton.transform.FindChild("Name").GetComponent<Text>();
			nameText.text = types[i].unitName;

			Text priceText = buildButton.transform.FindChild("Cost").GetComponent<Text>();
			priceText.text = types[i].buildCost.ToString();

			Text queueText = buildButton.transform.FindChild("Queued").GetComponent<Text>();
			queueText.text = "0";
			spawner.SetBuildCountText(queueText, types[i]);

			Button button = buildButton.GetComponent<Button>();
			
			int j = i;
			button.onClick.AddListener(() => buildUnit(types[j],queueText));


		}
		parentObject.transform.parent = unitCreateMenu.transform;
		unitButtons = parentObject;
	}

	private void buildUnit(UnitType type, Text queueText){
		int cost = (int)type.buildCost;
		if(econ.GetMoney()>cost){
			spawner.QueueUnit(lane,type);
			econ.RemoveMoney(cost);
		}
	}
	
}
