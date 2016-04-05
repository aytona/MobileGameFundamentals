using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuUI : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
}
