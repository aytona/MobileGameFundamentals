using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Gold : MonoBehaviour {

	private float left, right, coef;
	private float horizontal = 400f;
	private Rigidbody2D potBody;

	private float counter;

	void Start()
	{
		left = GameObject.Find ("LeftWall").transform.position.x + 1f;
		right = GameObject.Find ("RightWall").transform.position.x - 1f;
		coef = horizontal / (left - right);
	}
		
	public void AddCoin()
	{
		counter++;
	}

	public void ReceiveInput(float distance, Vector2 direction)
	{
		potBody = gameObject.GetComponent<Rigidbody2D>();
		direction.y = 0;
		potBody.AddForce(coef * direction * distance);
	}
}
