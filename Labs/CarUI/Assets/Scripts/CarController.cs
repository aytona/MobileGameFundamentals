using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public float CarSpeed;
	float MaxPos = 2.1f;
	Vector3 position;
	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		position = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		AccelerometerMove ();
		position = transform.position;
		position.x = Mathf.Clamp (position.x, -MaxPos, MaxPos);
		transform.position = position;
	}

	void AccelerometerMove() {
		
		float x = Input.acceleration.x;
		//negative=left, positive=right
		if (x < -0.1f) {
			MoveLeft ();
		} else if(x > 0.1f)  {
			MoveRight ();
		}
		else {
			SetVelocityZero ();
		}
	}

	public void MoveLeft() {
		rb.velocity = new Vector2 (-CarSpeed, 0);
	}
	public void MoveRight() {
		rb.velocity = new Vector2 (CarSpeed, 0);
	}
	public void SetVelocityZero() {
		rb.velocity = Vector2.zero;
	}
}
