using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToLane : MonoBehaviour {

	public RallyAnimation rallyQueue;
	public Sprite rallyQueueSprite;
	public Sprite rallyQueueExitSprite;
	private ScoreCard scoreCard;
	private bool wrongLane = false;

	void Start() {
		scoreCard = FindObjectOfType<ScoreCard>();
	}

	void Update() {
		if (wrongLane) {
			scoreCard.TimeInWrongLane(Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.ToString() == "Simulator Car (UnityEngine.GameObject)") {
			wrongLane = true;
			rallyQueue._rallyImage.sprite = rallyQueueSprite;
		}
	}

	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.ToString() == "Simulator Car (UnityEngine.GameObject)") {
			wrongLane = false;
			rallyQueue._rallyImage.sprite = rallyQueueExitSprite;
		}
	}
}
