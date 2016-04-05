using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartButton : MonoBehaviour {

	public void StartGame() {
		SceneManager.LoadScene(1);
	}
}
