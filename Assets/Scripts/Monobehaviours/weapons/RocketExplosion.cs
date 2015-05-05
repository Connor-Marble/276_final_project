using UnityEngine;
using System.Collections;

public class RocketExplosion : MonoBehaviour {

	private float destroyTime = 2f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
	}

}
