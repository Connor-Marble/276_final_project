using UnityEngine;
using System.Collections;

public class UnitSpawner : MonoBehaviour {

	public const int left   = 0;
	public const int middle = 1;
	public const int right  = 2;

	private Queue[] buildQueues;

	private GameObject[] unitTypes;

	// Use this for initialization
	void Start () {
		Queue leftBuildQueue = new Queue ();
		Queue middleBuildQueue = new Queue ();
		Queue rightBuildQueue = new Queue ();
		buildQueues = {leftBuildQueue, middleBuildQueue, rightBuildQueue};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
