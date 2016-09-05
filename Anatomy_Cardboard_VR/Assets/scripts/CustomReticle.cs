using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CustomReticle : GvrReticle {
	LayerMask saveLayer;
	public override void OnGazeTriggerStart(Camera camera) {
		RadialMenu.menus["MainMenu"].MoveToCameraCenter();
		RadialMenu.menus["MainMenu"].SetActive(true);
	}
		
	public override void OnGazeTriggerEnd(Camera camera) {
		foreach (var menu in RadialMenu.menus)
			menu.Value.SetActive (false);
		RotationMenu.instance.StopMoveBrain ();
		ZoomMenu.instance.ZoomStop ();
	}
}
