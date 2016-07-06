using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BrainController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		foreach(Transform child in transform)
		{
			child.gameObject.AddComponent (typeof(MeshCollider));
			change_color_ctrl color = child.gameObject.AddComponent (typeof(change_color_ctrl)) as change_color_ctrl;
			EventTrigger trigger = child.gameObject.AddComponent (typeof(EventTrigger)) as EventTrigger;

			EventTrigger.Entry onPointerEnter = new EventTrigger.Entry( );
			onPointerEnter.eventID = EventTriggerType.PointerEnter;
			onPointerEnter.callback.AddListener( ( data ) => { color.SetGazedAt(true); });
			trigger.triggers.Add(onPointerEnter);

			EventTrigger.Entry onPointerExit = new EventTrigger.Entry( );
			onPointerExit.eventID = EventTriggerType.PointerExit;
			onPointerExit.callback.AddListener( ( data ) => { color.SetGazedAt(false); });
			trigger.triggers.Add(onPointerExit);
		}
	}
	
	// Update is called once per frame
	void Update () {
		var rot = GvrViewer.Instance.HeadPose.Orientation;
		this.transform.localRotation = rot;
	}
}
