using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CustomReticle : GvrReticle {
	LayerMask saveLayer;
	public override void OnGazeTriggerStart(Camera camera) {
		PhysicsRaycaster ray = GvrViewer.Controller.cam.gameObject.GetComponent<PhysicsRaycaster> ();
		saveLayer = ray.eventMask;
//		string name = LayerMask.LayerToName (5);
//		ray.eventMask = new LayerMask{ value = 5 };
		RadioMenu.Instance.MoveToCameraCenter ();
		RadioMenu.Instance.SetActive(true);
	}
		
	public override void OnGazeTriggerEnd(Camera camera) {
		//GvrViewer.Controller.cam.gameObject.GetComponent<PhysicsRaycaster> ().eventMask.value = 2;
		RadioMenu.Instance.SetActive (false);
		//GvrViewer.Controller.cam.gameObject.GetComponent<PhysicsRaycaster> ().eventMask = saveLayer;
	}
}
