using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//structure to hold information
//used to build units
[System.Serializable]
public struct UnitType{
	public GameObject prefab;
	//time to build in seconds
	public float buildTime;
	public float buildCost;
	public string unitName;
}

public class UnitSpawner : MonoBehaviour {

	[SerializeField]
	private UnitType[] unitTypes;
	private string[] goals = {"Left", "Mid", "Right"};

	public const int left   = 0;
	public const int middle = 1;
	public const int right  = 2;

	[SerializeField]
	private Transform[] spawnPoints;

	private float[] buildStartTimes;

	private Queue[] buildQueues;

	private float buildCheckDelay = 0.5f;
	public Text[] queueCounts;

	private int activeLane;

	// Use this for initialization
	void Start () {
		Queue leftBuildQueue = new Queue ();
		Queue middleBuildQueue = new Queue ();
		Queue rightBuildQueue = new Queue ();
		buildQueues = new Queue[3]{leftBuildQueue, middleBuildQueue, rightBuildQueue};

		buildStartTimes = new float[3];

		InvokeRepeating ("UpdateBuildQueues", 0f, buildCheckDelay);
		queueCounts = new Text[unitTypes.Length];
	}

	public UnitType[] GetUnitTypes(){
		return unitTypes;
	}

	private void UpdateBuildQueues(){
		for (int i =0; i<buildQueues.Length; i++) {
			if(buildQueues[i].Count>0){
				UnitType unit = (UnitType)buildQueues[i].Peek();
				if(unit.buildTime+buildStartTimes[i]<Time.timeSinceLevelLoad){
					spawnUnitType(i, unit);
					buildQueues[i].Dequeue();
					buildStartTimes[i] = Time.timeSinceLevelLoad;
				}
			}
		}
		UpdateBuildCountText ();
	}
	
	void spawnUnitType(int lane, UnitType type){
		GameObject unit = (GameObject)Instantiate (type.prefab, spawnPoints[lane].position, spawnPoints[lane].rotation);
		UnitBase unitBase = unit.GetComponent<UnitBase>();
		unitBase.startGoalName = goals[lane];
	}

	public void QueueUnit(int lane, UnitType type){
		buildQueues [lane].Enqueue (type);
		if (buildQueues [lane].Count == 1) {
			buildStartTimes[lane]=Time.timeSinceLevelLoad;
		}
		UpdateBuildCountText ();
	}

	public int GetNumberQueued(int lane, UnitType type){
		int count = 0;
		foreach (UnitType unit in buildQueues[lane]) {
			if(unit.unitName == type.unitName){
				count++;
			}
		}
		return count;
	}

	public void SetBuildCountText(Text text, UnitType type){
		queueCounts [ GetIndexOfUnit (type)] = text;
	}

	private void UpdateBuildCountText (){
		for(int i =0;i<queueCounts.Length;i++){
			int count = GetNumberQueued(activeLane,unitTypes[i]);
			queueCounts[i].text = count.ToString();
		}
	}

	private int GetIndexOfUnit(UnitType type){
		for (int i = 0; i<unitTypes.Length; i++) {
			if(unitTypes[i].unitName == type.unitName)
				return i;
		}
		return -1;
	}
	public void setActiveLane(int activeLane){
		this.activeLane = activeLane;
		UpdateBuildCountText ();
	}
}
