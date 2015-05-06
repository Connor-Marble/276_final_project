using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EconomySystem : MonoBehaviour{

	private int bank = 50;
	
	[SerializeField]
	public Text bankText;
	
	[SerializeField]
	private int income = 5;

	void Start(){
		InvokeRepeating("CollectIncome", 1f, 1f);
	}

	void Update(){
		bankText.text = Mathf.RoundToInt(bank).ToString();
	}

	public void AddMoney(int profit){		
		bank += profit;
	}
	
	private void CollectIncome(){
		bank += income;
	}

	public void RemoveMoney(int debt){
		bank -= debt;
	}
	
	public int GetMoney(){
		return bank;
	}
	
	public void IncreaseIncome(int amount){
		income += amount;
	}
}