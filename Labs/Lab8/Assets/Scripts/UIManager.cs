using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	public void Pause() {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
	}
}
