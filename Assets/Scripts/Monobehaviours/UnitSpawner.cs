using UnityEngine;
using System.Collections;

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

	public const int left   = 0;
	public const int middle = 1;
	public const int right  = 2;

	private Queue[] buildQueues;

	// Use this for initialization
	void Start () {
		Queue leftBuildQueue = new Queue ();
		Queue middleBuildQueue = new Queue ();
		Queue rightBuildQueue = new Queue ();
		buildQueues = new Queue[3]{leftBuildQueue, middleBuildQueue, rightBuildQueue};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
