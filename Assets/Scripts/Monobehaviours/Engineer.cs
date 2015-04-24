using UnityEngine;
using System.Collections;

public class Engineer : Hero {	

	int buildRate = 1;	

	// Use this for initialization
	public override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}

	public void BuildTower(GameObject preTower, GameObject postTower, Vector3 location, int cost){
		
		Object buildTower = Instantiate(preTower, location, Quaternion.identity);
		Destroy(buildTower, CalculateBuildTime(cost));
		Instantiate(postTower, location, Quaternion.identity);
	}

	float CalculateBuildTime(int cost){
		return ((float)cost/buildRate);
	}
}
