using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour {

	public Ball ball;

	public struct SimpleTouch {
		public Vector2 StartTouchLocation;
		public Vector2 CurrentTouchLocation;
		public TouchPhase Phase;
	}

	private SimpleTouch ActiveTouch;
	private Touch DeviceTouch;
	private Vector2 theSwipe;

	private void CalculateSwipe(SimpleTouch CurrentTouch) {
		theSwipe = CurrentTouch.CurrentTouchLocation - CurrentTouch.StartTouchLocation;
	}

	void Start() {
		ActiveTouch.Phase = TouchPhase.Canceled;
	}

	void Update() {
		if (Application.isEditor) {
			if (Input.GetMouseButton (0)) {
				if (ActiveTouch.Phase == TouchPhase.Canceled) {
					ActiveTouch.CurrentTouchLocation = Input.mousePosition;
					ActiveTouch.StartTouchLocation = Input.mousePosition;
					ActiveTouch.Phase = TouchPhase.Began;
				} else {
					ActiveTouch.CurrentTouchLocation = Input.mousePosition;
				}
				CalculateSwipe (ActiveTouch);
				ball.ReceiveInput (theSwipe);
			}
		} else {

		}
	}
}
