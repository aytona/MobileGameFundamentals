using UnityEngine;
using System.Collections;

public class LevelPiece : MonoBehaviour {

	private Vector3 InitialLocation;

	void Awake() {
		InitialLocation = transform.position;
	}

	public Vector3 GetInitialLocation() {
		return InitialLocation;
	}
}
