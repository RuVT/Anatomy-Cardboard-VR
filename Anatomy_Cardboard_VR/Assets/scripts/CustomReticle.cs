using UnityEngine;
using System.Collections;

public class CustomReticle : GvrReticle {
	GvrHead head; 
	Quaternion cameraRotation, modelRotation;
	Vector3 cameraPosition;
	public override void OnGazeTriggerStart(Camera camera) {
//		if(head == null)
//			head = camera.GetComponentInParent<GvrHead> ();
//		modelRotation = BrainController.instance.transform.rotation;
//		cameraRotation = head.transform.rotation;
//		cameraPosition = head.transform.position;
//		GvrViewer.Instance.Recenter ();
//		head.trackPosition = true;
//		head.trackRotation = true;
//		BrainController.instance.trackOrientation = false;
//		Debug.Log ("OnGazeTriggerStart");
	}
		
	public override void OnGazeTriggerEnd(Camera camera) {
//		Debug.Log ("OnGazeTriggerEnd");
//		head.trackPosition = false;
//		head.trackRotation = false;
//		BrainController.instance.transform.rotation = modelRotation;
//		head.transform.rotation = cameraRotation;
//		head.transform.position = cameraPosition;
//		GvrViewer.Instance.Recenter ();
//		BrainController.instance.trackOrientation = true;

	}
}
