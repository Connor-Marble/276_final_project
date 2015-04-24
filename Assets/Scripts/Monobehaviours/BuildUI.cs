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

	// Use this for initialization
	void Start () {
		spawner = GetComponent<UnitSpawner> ();
		createUnitButtons (Vector2.one*spawner.GetUnitTypes().Length, 20f);
		HideUI ();
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
		for (int i =0; i<types.Length; i++) {
			GameObject buildButton = Instantiate(unitButtonPrefab);
			RectTransform buttonTrans = buildButton.GetComponent<RectTransform>();
			buildButton.transform.position = new Vector2(
					Mathf.Lerp(-size.x*buttonTrans.sizeDelta.x/2 + Screen.width/2, 
			        size.x*buttonTrans.sizeDelta.x/2 + Screen.width/2,
			        ((float)i)/((float)types.Length)),
					yOffset + buttonTrans.sizeDelta.y);

			buttonTrans.position += (Vector3)Vector2.right*buttonTrans.sizeDelta.x/2;
			buildButton.transform.SetParent(parentObject.transform);

			buttonTrans.localScale = size/types.Length;

			Text nameText = buildButton.transform.FindChild("Name").GetComponent<Text>();
			nameText.text = types[i].unitName;

			Text priceText = buildButton.transform.FindChild("Cost").GetComponent<Text>();
			priceText.text = types[i].buildCost.ToString();

			Text queueText = buildButton.transform.FindChild("Queued").GetComponent<Text>();
			queueText.text = "0";

			Button button = buildButton.GetComponent<Button>();
			int j = i;
			button.onClick.AddListener(() => buildUnit(types[j]));


		}
		parentObject.transform.parent = unitCreateMenu.transform;
		unitButtons = parentObject;
	}

	private void buildUnit(UnitType type){
		spawner.spawnUnitType(lane, type);
	}
	
}
