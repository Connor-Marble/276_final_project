using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	[SerializeField]
	private float startHealth;
	private float health;

	void Start(){
		health = startHealth;
	}

	public float GetHealth(){
		return health;
	}

	public float GetRelativeHealth(){
		return health / startHealth;
	}

	public void Heal(float amount){
		health += amount;
	}

	public void Damage(float amount){
		health -= amount;
		if (health < 0)
			Die ();
	}

	void Die(){
		Destroy (this.gameObject);
	}
}
