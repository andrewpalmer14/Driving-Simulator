using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingCollisionHandler : MonoBehaviour {

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.gameObject.ToString() == "Simulator Car (UnityEngine.GameObject)") {
			SceneManager.LoadScene("Score Scene");
		}
	}
}
