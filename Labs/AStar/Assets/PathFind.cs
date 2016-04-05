using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFind : MonoBehaviour {

	public Transform seeker, target;
	Grid grid;

	void Awake() {
		grid = GetComponent<Grid> ();
	}

	void FindPath(Vector3 startPos, Vector3 targetPos) {

		//Node startNode 

	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
