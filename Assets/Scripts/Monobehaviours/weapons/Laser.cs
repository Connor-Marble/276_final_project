using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour, IWeapon {

	[SerializeField]
	private float fireDelay = 1f;

	[SerializeField]
	private float range = 8f;
	[SerializeField]
	private float damage = 1f;

	[SerializeField]
	private Transform origin;

	private float lastFire;

	[SerializeField]
	private GameObject effect;

	#region IWeapon implementation

	public void Fire (GameObject target)
	{
		lastFire = Time.timeSinceLevelLoad;
		HealthSystem targetHealth = target.GetComponent<HealthSystem> ();
		if (targetHealth != null) {
			targetHealth.Damage(damage);
			GameObject laser = (GameObject)Instantiate(effect, target.transform.position, Quaternion.identity);
			LaserEffect fireEffect = laser.GetComponent<LaserEffect>();
			fireEffect.origin = this.origin.position;
			fireEffect.target = target.transform.position;
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
