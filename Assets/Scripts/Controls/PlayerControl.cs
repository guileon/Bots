using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
	private Rigidbody rb;
	private float x;
	private float y;
	Vector3 targetPosition;
	bool semaforol;
	enum movements {up, down, left, right, none};
	Queue<movements> movementQueue;

	Transform target;

	void Start () {
		semaforol = false;
		movementQueue = new Queue<movements> ();
		x = 0;
		y = 0;
		rb =GetComponentInChildren<Rigidbody>();
		targetPosition = rb.position;
	}

	void Update () {
//		rb.AddForce (new Vector3 (1, 0, 0));
//
//		Object g = Resources.Load ("Prefabs/ghost");
//		Object h = Instantiate(g,positi
//
//		if (Physics.CheckSphere (new Vector3(this.transform.position.x, 0, this.transform.position.z) + new Vector3 (3, 0, 0), .2f)) {
//			Debug.Log ("CaCAroto");
//		} else
//			Debug.Log ("Kurumin");

//		rb.rotation = Quaternion.identity;
//
//		Vector3 movementDirection = new Vector3 (0, 0, 0);
//		Vector3 currentPosition = rb.position;
//		const float speed = 1;

		float step = 0.3f;

		var go = getNextMovement () + transform.position;

		Vector3 velocity = Vector3.zero;
		Debug.Log (go);
		rb.position = Vector3.SmoothDamp (transform.position, go, ref velocity, step);
//		if (nextMovement != movements.none) {
//			movementQueue.Enqueue (nextMovement);
//			semaforol = true;
//			currentPosition = rb.position;
//		}
//
//		if (Vector3.Magnitude (rb.position - targetPosition) > .01f) {
//			Vector3 velocity = rb.velocity;
//			rb.position = Vector3.SmoothDamp (currentPosition, targetPosition, ref velocity, .001f);
//			rb.velocity = velocity;
//		}

		/*semaforol = movementList.Count > 0 ? true : false;


		if (semaforol) {
			if (Mathf.Abs (y) < .1f && Mathf.Abs (x) > .1f) {

				movementDirection = new Vector3 (Mathf.Sign (x) * speed, 0, 0);
				x = 0;
			}
			if (Mathf.Abs (x) < .1f && Mathf.Abs (y) > .1f) {
				
				movementDirection = new Vector3 (0, 0, Mathf.Sign (y) * speed);
				y = 0;
			}

			currentPosition = rb.position;
			targetPosition = currentPosition + movementDirection;

			semaforol = false;
		}
		Vector3 velocity = rb.velocity;
		rb.position = Vector3.SmoothDamp (currentPosition, targetPosition, ref velocity, .001f);
		rb.velocity = velocity;*/


	}

	private Vector3 getNextMovement(){
		if (Input.GetKeyDown (KeyCode.UpArrow))
			return(new Vector3(1,0,0));
		else if (Input.GetKeyDown (KeyCode.DownArrow))
			return(new Vector3(-1,0,0));
		else if (Input.GetKeyDown (KeyCode.LeftArrow))
			return(new Vector3(0,0,-1));
		else if (Input.GetKeyDown (KeyCode.RightArrow))
			return(new Vector3(0,0,1));
		else
			return(new Vector3(0,0,0));
	}
}
