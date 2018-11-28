using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingCollisionHandler : MonoBehaviour {

	private ScoreCard scoreCard;

	void Start() {
		scoreCard = FindObjectOfType<ScoreCard>();
	}
	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.gameObject.ToString() == "Simulator Car (UnityEngine.GameObject)") {
			scoreCard.SetTrackFinished(false);
			SceneManager.LoadScene("Score Scene");
		}
	}
}
