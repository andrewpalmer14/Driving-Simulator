using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class FailTrigger : MonoBehaviour
{
    public CarController carController;
    public GameObject passTrigger;
    public LightAnimation lightQueue;
    public StopLight stopLight;
    private ScoreCard scoreCard;

    // Use this for initialization
    void Start()
    {
        scoreCard = FindObjectOfType<ScoreCard>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.ToString() == "Simulator Car (UnityEngine.BoxCollider)")
        {
            if (stopLight != null)
            {
                if (stopLight.getCurrentLight() == "RED")
                {
                    Debug.Log("Failed stop light!");
                    scoreCard.UnsuccessfulLightSequence();
                    lightQueue.trafficLight = true;
                    this.gameObject.SetActive(false);
                    passTrigger.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Stop test failed!");
                scoreCard.UnsuccessfulStop();
                if (lightQueue != null) {
                    lightQueue.trafficLight = true;
                }
                this.gameObject.SetActive(false);
                if (passTrigger != null)
                {
                    passTrigger.SetActive(false);
                }
            }
        }
    }
}
