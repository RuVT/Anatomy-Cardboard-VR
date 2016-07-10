using UnityEngine;
using System.Collections;

public class CustomReticle : GvrReticle {
	GvrHead head; 

	public override void OnGazeTriggerStart(Camera camera) {
		if(head == null)
			head = camera.GetComponentInParent<GvrHead> ();
		head.trackPosition = true;
		head.trackRotation = true;
		Debug.Log ("OnGazeTriggerStart");
	}
		
	public override void OnGazeTriggerEnd(Camera camera) {
		Debug.Log ("OnGazeTriggerEnd");
		head.trackPosition = false;
		head.trackRotation = false;
	}
}
