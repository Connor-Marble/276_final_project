using UnityEngine;
using System.Collections;

public class GroundTexScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Material mat = GetComponent<Renderer> ().material;
		Vector2 startScale = mat.mainTextureScale;
		startScale.x *= transform.localScale.x;
		startScale.y *= transform.localScale.z;
		mat.mainTextureScale = startScale;
	}

}
