using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class TriggerTestPassed : MonoBehaviour {

	public CarUserControl carUserControl;

	void OnTriggerEnter(Collider collider) {
		if (collider.ToString() == "Simulator Car (UnityEngine.BoxCollider)") {
			carUserControl.TestPassed();
			this.gameObject.SetActive(false);
		}
	}
}
