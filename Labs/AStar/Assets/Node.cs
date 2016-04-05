using UnityEngine;
using System.Collections;

public class Node {
	public Vector3 worldPosition;
	public int gridX;
	public int gridY;
	public bool walkable;
	public int gCost;
	public int hCost;
	public Node parent;

	public Node(bool _walkable, 
		Vector3 _worldPosition, int _gridx, int _gridy) {
		worldPosition = _worldPosition;
		walkable = _walkable;
		gridX = _gridx;
		gridY = _gridy;
	}

	public int fCost {
		get {
			return gCost + hCost;
		}
	}

}
