using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateTrigger : MonoBehaviour {

    public RallyAnimation rallyQueue;
    public LightAnimation lightQueue;
    public StopLight stopLight;
    public Sprite rallyQueueSprite;
    public GameObject passTrigger;
    public GameObject failTrigger;
    public bool stopLightTest;

    public ReturnToLane returnToLaneTriggerActive;
    public ReturnToLane returnToLaneTriggerDisable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.ToString() == "Simulator Car (UnityEngine.BoxCollider)")
        {
            if (returnToLaneTriggerDisable != null) {
                returnToLaneTriggerDisable.gameObject.SetActive(false);
            }
            if (returnToLaneTriggerActive != null) {
                returnToLaneTriggerActive.gameObject.SetActive(true);
            } else {
                SceneManager.LoadScene("Score Scene");
            }
            if (stopLightTest)
            {
                lightQueue.trafficLight = false;
            }
            rallyQueue._rallyImage.sprite = rallyQueueSprite;
            if (passTrigger != null)
            {
                passTrigger.SetActive(true);
                
            }
            if (failTrigger != null)
            {

                failTrigger.SetActive(true);
            }
        }
    }


}
