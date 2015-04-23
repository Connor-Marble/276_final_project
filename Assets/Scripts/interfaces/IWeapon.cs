using UnityEngine;
using System.Collections;

public interface IWeapon {

	void Fire(GameObject target);

	bool IsReady();

	float GetRange();
}
