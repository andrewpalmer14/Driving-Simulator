using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public GameObject[] testTriggerGameObjects;
        public String[] feedbackStrings;
        public int[] speedLimits;
        public Transform[] checkPoints;
        public String[] rallyQueueStrings;
        private int testIndex = 0;
        public Text speedText;
        public Text rallyQueueText;
        public Text feedBackText;
        public Text speedLimitText;

        public Image needle;
        public Image shifter;
        public Sprite drive;
        public Sprite reverse;

        public int[] testFailures;
        public bool[] passedTests;

        private void Awake()
        {
            foreach (GameObject trigger in testTriggerGameObjects) {
                trigger.SetActive(false);
            }
            testTriggerGameObjects[testIndex].SetActive(true);
            rallyQueueText.text = "Right";
            speedLimitText.text = "Speed Limit: " + speedLimits[testIndex];
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        public void TestPassed() {
            Debug.Log("test " + testIndex + " passed");
            passedTests[testIndex] = true;
            testTriggerGameObjects[testIndex].SetActive(false);
            testIndex++;
            rallyQueueText.text = rallyQueueStrings[testIndex];
            speedLimitText.text = "Speed Limit: " + speedLimits[testIndex];
            testTriggerGameObjects[testIndex].SetActive(true);
        }

        public void TestFailed() {
            testFailures[testIndex]++; 
            this.transform.position = checkPoints[testIndex].position;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.R) || CrossPlatformInputManager.GetButtonDown("Reverse")) {
                m_Car.SwitchReverseBool();
            }

            if (m_Car.GetInReverse()) {
                shifter.sprite = reverse;
            } else {
                shifter.sprite = drive;
            }
        }


        private void FixedUpdate()
        {

            float rotationDegree = (95.0f - m_Car.CurrentSpeed * 2.38f);

            needle.transform.rotation = Quaternion.Euler(0, 0, rotationDegree);
            if (Math.Round(m_Car.CurrentSpeed) > speedLimits[testIndex]) {
                feedBackText.text = "Slow Down!";
            } else {
                feedBackText.text = feedbackStrings[testIndex];
            }
            speedText.text = Math.Round(m_Car.CurrentSpeed) + " MPH";
            if (m_Car.GetInReverse()) {
                //Debug.Log("in reverse");
                //Debug.Log("Speed: " + m_Car.CurrentSpeed + " Accel: " + m_Car.AccelInput + " Break: " + m_Car.BrakeInput);

            } else {
                //Debug.Log("not in reverse");
            }
            //Debug.Log("Speed: " + m_Car.CurrentSpeed + " Accel: " + m_Car.AccelInput + " Break: " + m_Car.BrakeInput);
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Brake");
            m_Car.Move(h, v, v, handbrake);
            
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }

}
