using UnityEngine;
using System.Collections;


[RequireComponent(typeof(HealthSystem))]
public class HealthBar : MonoBehaviour {

	[SerializeField]
	private Texture barTex;

	private HealthSystem health;

	[SerializeField]
	private float width = 10f;

	[SerializeField]
	private float height = 3f;

	[SerializeField]
	private float offsetHeight = 25f;

	private bool display;

	private Renderer renderer;
	// Use this for initialization
	void Start () {
		health = GetComponent<HealthSystem> ();
		InvokeRepeating ("CheckHit", Random.value, 0.3f);
		renderer = transform.GetComponentInChildren<Renderer> ();
	}

	void CheckHit(){
		display = health.GetRelativeHealth () < 1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (display&&renderer.isVisible) {
			GUI.color = Color.Lerp (Color.red, Color.green, health.GetRelativeHealth ());
			Vector3 top = transform.TransformPoint (Vector3.up);
			Vector3 barPos = Camera.main.WorldToScreenPoint (top);
			GUI.DrawTexture (new Rect (barPos.x - width, Screen.height - barPos.y + height - offsetHeight, width * 2, height), barTex);

		}
	}
}
