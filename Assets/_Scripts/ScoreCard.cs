using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCard : MonoBehaviour {

	private int score = 100;
	private int unsuccessfulLightSequences = 0;
	private int successfulLightSequences = 0;
	private int unsuccessfulStops = 0;
	private int successfulStops = 0;
	private float timeInWrongLane = 0;
    private float timeAboveSpeed = 0;

	private bool trackFinished = false;

	private float timeElapsed = 0;

	void Start() {
		DontDestroyOnLoad(this.gameObject);
	}

	void Update() {
		timeElapsed += Time.deltaTime;
	}

	public void TimeInWrongLane(float time) {
		this.timeInWrongLane += time;
	}

    public void TimeAboveSpeed(float time)
    {
        this.timeAboveSpeed += time;
    }

	public void SuccessfulStop() {
		this.successfulStops++;
	}

	public void UnsuccessfulStop() {
		this.unsuccessfulStops++;
		this.score -= 41;
		if (this.score < 0) {
			this.score = 0;
		}
	}

	public void SuccessfulLightSequence() {
		this.successfulLightSequences++;
	}

	public void UnsuccessfulLightSequence() {
		this.unsuccessfulLightSequences++;
		this.score -= 41;
		if (this.score < 0) {
			this.score = 0;
		}
	}

	public void SetTrackFinished(bool trackFinished) {
		this.trackFinished = trackFinished;
	}

	public bool GetTrackFinished() {
		return this.trackFinished;
	}

	public int GetScore() {
		if (trackFinished) {
			return this.score - (Mathf.RoundToInt(this.timeInWrongLane)) - (Mathf.RoundToInt(this.timeAboveSpeed));
		} else {
			return 0;
		}
	}

	public string GetSuccessfulLightSequenceRatio() {
		return "" + this.successfulLightSequences + "/" + (this.unsuccessfulLightSequences + this.successfulLightSequences);
	}

	public string GetSuccessfulStopRatio() {
		return "" + this.successfulStops + "/" + (this.unsuccessfulStops + this.successfulStops);
	}

    public int GetUnsuccessfulStops()
    {
        return this.unsuccessfulStops;
    }

    public int GetUnsuccessfulLightSequences()
    {
        return this.unsuccessfulLightSequences;
    }

	public float GetTimeInCorrectLane() {
		return (this.timeElapsed - this.timeInWrongLane);
	}

	public float GetTimeInWrongLane() {
		return (this.timeInWrongLane);
	}

    public int GetTimeAboveSpeed()
    {
        return Mathf.RoundToInt(this.timeAboveSpeed);
    }

}
