using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private Transform t;
	private Rigidbody rb;
	private float x;
	private float y;
	void Start () {
		x = 0;
		y = 0;
		t = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");
		t.Translate (new Vector3 (x, 0, y));

	}
}
