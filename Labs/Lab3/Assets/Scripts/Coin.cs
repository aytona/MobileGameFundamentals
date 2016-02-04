using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour {

	private float top, bottom, left, right, yCoord, xCoord;
	private Rigidbody2D rb2d;
	private Gold counter;

	#region MonoBehaviour
	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
		left = GameObject.Find ("LeftWall").transform.position.x + 1f;
		right = GameObject.Find ("RightWall").transform.position.x - 1f;
		bottom = GameObject.Find ("Floor").transform.position.y + 1f;
		top = GameObject.Find ("Ceiling").transform.position.y - 1f;
		counter = GameObject.FindObjectOfType<Gold> ();
	}
	void Update() {
		yCoord = rb2d.transform.position.y;
		xCoord = rb2d.transform.position.x;
		if (yCoord < bottom) {
			ResetPosition ();
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Gold") {
			ResetPosition ();
			counter.AddCoin ();
		}
	}
	#endregion MonoBehaviour

	#region Private Functions
	private void ResetPosition()
	{
		xCoord = Random.Range (left,right);
		rb2d.transform.position = new Vector2 (xCoord, top);
		rb2d.velocity = new Vector3 (0,0,0);
	}
	#endregion Private Functions
}
