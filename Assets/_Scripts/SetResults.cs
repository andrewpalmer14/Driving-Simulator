using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResults : MonoBehaviour {

	private ScoreCard scoreCard;
	public Text legalSequences;
	public Text correctStops;
	public Text completedCircuit;
	public Text timeInCorrectLane;
	public Text timeInIncorrectLane;
	public Text timeRatio;
	public Text totalScorePercentage;

	// Use this for initialization
	void Start () {
		scoreCard = FindObjectOfType<ScoreCard>();
			if (scoreCard != null) {
			legalSequences.text = scoreCard.GetSuccessfulLightSequenceRatio();
			correctStops.text = scoreCard.GetSuccessfulStopRatio();
			if (scoreCard.GetTrackFinished()) {
				completedCircuit.text = "yes";
			} else {
				completedCircuit.text = "no";
			}
			timeInCorrectLane.text = scoreCard.GetTimeInCorrectLane().ToString() + " seconds";
			timeInIncorrectLane.text = scoreCard.GetTimeInWrongLane().ToString() + " seconds";
			timeRatio.text = (scoreCard.GetTimeInCorrectLane()/(scoreCard.GetTimeInWrongLane() + scoreCard.GetTimeInCorrectLane())).ToString();
			totalScorePercentage.text = scoreCard.GetScore().ToString() + "%";
		} else {
			Debug.Log("could not find score card");
		}
	}
}
