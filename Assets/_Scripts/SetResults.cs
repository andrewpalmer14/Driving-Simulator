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
    public Text timeSpeeding;

	// Use this for initialization
	void Start () {
		scoreCard = FindObjectOfType<ScoreCard>();
			if (scoreCard != null) {
			legalSequences.text = scoreCard.GetSuccessfulLightSequenceRatio() + "(-" + scoreCard.GetUnsuccessfulLightSequences() * 41 + "pts)";
			correctStops.text = scoreCard.GetSuccessfulStopRatio() + "(-" + scoreCard.GetUnsuccessfulStops() * 41 + "pts)";
			if (scoreCard.GetTrackFinished()) {
				completedCircuit.text = "yes";
			} else {
				completedCircuit.text = "no (instant failure)";
			}
			timeInCorrectLane.text = scoreCard.GetTimeInCorrectLane().ToString() + " seconds";
            timeInIncorrectLane.text = scoreCard.GetTimeInWrongLane().ToString() + " seconds (-" + scoreCard.GetTimeInWrongLane() + "pts)";
			timeRatio.text = (scoreCard.GetTimeInCorrectLane()/(scoreCard.GetTimeInWrongLane() + scoreCard.GetTimeInCorrectLane())).ToString();
			totalScorePercentage.text = scoreCard.GetScore().ToString() + "%";
            timeSpeeding.text = scoreCard.GetTimeAboveSpeed().ToString() + " seconds (-" + scoreCard.GetTimeAboveSpeed() + "pts)";
		} else {
			Debug.Log("could not find score card");
		}
	}
}
