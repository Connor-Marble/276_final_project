using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EconomySystem : MonoBehaviour{

	public int bank = 500;

	public Text bankText;

	void Update(){
		bankText.text = bank.ToString();
	}

	public void AddMoney(int profit){		
		bank += profit;
	}

	public void RemoveMoney(int debt){
		bank -= debt;
	}
}