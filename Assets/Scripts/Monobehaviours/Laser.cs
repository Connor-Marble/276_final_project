using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour, IWeapon {

	[SerializeField]
	private float fireDelay = 1f;

	[SerializeField]
	private float range = 5f;

	[SerializeField]
	private float damage = 1f;

	private float lastFire;

	#region IWeapon implementation

	public void Fire (GameObject target)
	{
		Debug.Log ("firing");
		lastFire = Time.timeSinceLevelLoad;
		HealthSystem targetHealth = target.GetComponent<HealthSystem> ();
		Debug.DrawLine (transform.position, target.transform.position);
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
