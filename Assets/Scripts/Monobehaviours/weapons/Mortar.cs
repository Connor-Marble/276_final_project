using UnityEngine;
using System.Collections;

public class Mortar : MonoBehaviour, IWeapon {

	[SerializeField]
	private float reloadTime = 8f;
	private float lastFire;
	[SerializeField]
	private float range = 20f;
	
	
	[SerializeField]
	GameObject shell;
	
	[SerializeField]
	private Transform launcher;

	// Use this for initialization
	void Start () {
		lastFire = Time.timeSinceLevelLoad- reloadTime;
	}
	

	#region IWeapon implementation

	public void Fire (GameObject target)
	{
		lastFire = Time.timeSinceLevelLoad;
		GameObject shell_inst =(GameObject)Instantiate(shell, launcher.position, Quaternion.identity);
		Shell script = shell_inst.GetComponent<Shell>();
		script.target = target.transform.position;
	}

	public bool IsReady ()
	{
		return Time.timeSinceLevelLoad > lastFire+reloadTime;
	}

	public float GetRange ()
	{
		return range;
	}

	#endregion
}
