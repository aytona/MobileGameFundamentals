using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public float force = 100f;

	Rigidbody2D bouncyBall;

	void Start() {
		bouncyBall = gameObject.GetComponent<Rigidbody2D> ();
	}

	public void ReceiveInput(Vector2 theSwipe) {
		bouncyBall.AddForce (force * theSwipe.normalized);
	}
}
