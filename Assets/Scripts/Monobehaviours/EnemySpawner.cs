using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	[SerializeField]
	private float rampRate;
	[SerializeField]
	private GameObject[] units;
	[SerializeField]
	private float[] unitCosts;
	private float difficulty = 0f;
	// Use this for initialization
	private int lane = 0;
	
	[SerializeField]
	private Transform[] lanes;
	
	[SerializeField]
	private float maxDifficulty;
	private string[] laneGoals = {"Left", "Mid", "Right"};
	void Start () {
		StartCoroutine(RollWave());
	}
	
	// Update is called once per frame
	void Update () {
		difficulty += rampRate*Time.deltaTime;
	}
	
	IEnumerator RollWave(){
		yield return new WaitForSeconds(15f);
		lane = Random.Range(0,3);
		if(true){
			GameObject[] wave =CreateWave();
			StartCoroutine(SpawnWave(wave));
		} else{	
			StartCoroutine(RollWave());
		}
		
	}
	
	GameObject[] CreateWave(){
		float waveDiff = difficulty;
		Stack unitStack = new Stack(0);
		while(waveDiff>unitCosts[0]){
			int index = Random.Range(0,units.Length-1);
			if(unitCosts[index]<difficulty){
				waveDiff -= unitCosts[index];
				unitStack.Push(units[index]);
			}
		}
		GameObject[] result = new GameObject[unitStack.Count];
		for (int i = 0; i<result.Length; i++) {
			result[i] = (GameObject)unitStack.Pop();
		}
		return result;
	}
	
	IEnumerator SpawnWave(GameObject[] toSpawn){
		for(int i =0;i<toSpawn.Length;i++){
			GameObject newUnit = (GameObject)Instantiate(toSpawn[i], lanes[lane].position, toSpawn[i].transform.rotation);
			UnitBase uBase = newUnit.GetComponent<UnitBase>();
			uBase.startGoalName=laneGoals[lane];
			yield return new WaitForSeconds(1f);
		}
		StartCoroutine(RollWave());
	}
	
}
