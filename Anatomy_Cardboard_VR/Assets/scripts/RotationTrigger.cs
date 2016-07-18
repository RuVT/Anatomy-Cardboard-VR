using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RotationTrigger :  EventTrigger {
	public bool left;
	public bool right;
	public bool up;
	public bool down;

	void Start(){		
		left = gameObject.name.Contains ("left");
		right = gameObject.name.Contains ("right");
		up = gameObject.name.Contains ("up");
		down = gameObject.name.Contains ("down");
	}

	public override void OnPointerEnter(PointerEventData data){	
		float rotRate = BrainController.instance.rotationRate;	
		Vector3 rot = new Vector3 (0.0f, 0.0f, 0.0f);
		if (left) {
			rot.y = rotRate;
		}
		if (right) {
			rot.y = -rotRate;
		}
		if (up) {
			rot.x = rotRate;
		}
		if (down) {
			rot.x = -rotRate;
		}
		BrainController.instance.addRotation = rot;
	}

	public override void OnPointerExit(PointerEventData data){
		Vector3 rot = new Vector3 (0.0f, 0.0f, 0.0f);
		BrainController.instance.addRotation = rot;
	}
}
