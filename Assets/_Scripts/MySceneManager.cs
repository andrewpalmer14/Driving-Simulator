using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {

	public void GoToSimulatorScene() {
		SceneManager.LoadScene("Driving Simulator Scene");
	}

	public void GoToScoreScene() {
		SceneManager.LoadScene("Score Scene");
	}

	public void GoToHomeScene() {
		SceneManager.LoadScene("Home Scene");
	}

}
