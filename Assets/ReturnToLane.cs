using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToLane : MonoBehaviour {

	public RallyAnimation rallyQueue;
	public Sprite rallyQueueSprite;
	public Sprite rallyQueueExitSprite;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.ToString() == "Simulator Car (UnityEngine.GameObject)") {
			rallyQueue._rallyImage.sprite = rallyQueueSprite;
		}
	}

	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.ToString() == "Simulator Car (UnityEngine.GameObject)") {
			rallyQueue._rallyImage.sprite = rallyQueueExitSprite;
		}
	}
}
