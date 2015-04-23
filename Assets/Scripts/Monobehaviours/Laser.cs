using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour, IWeapon {

	[SerializeField]
	private float fireDelay = 1f;

	[SerializeField]
	private float range = 5f;

	private float damage;

	private float lastFire;

	#region IWeapon implementation

	public void Fire (GameObject target)
	{
		lastFire = Time.timeSinceLevelLoad;
		HealthSystem targetHealth = target.GetComponent<HealthSystem> ();
		if (targetHealth != null) {
			targetHealth.Damage(damage);
		}
	}

	public bool IsReady ()
	{
		return lastFire + fireDelay < Time.timeSinceLevelLoad;
	}

	public float GetRange(){
		return range;
	}

	#endregion
}
