using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BrainController : MonoBehaviour {

	public static BrainController instance;
	public bool trackOrientation = true;
	public Vector3 addRotation { get; set;}
	public float rotationRate;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else {
			BrainController.Destroy (this);
		}
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
		rotationRate = 1.0f;
	}

	void SetRotationPanel(){
			
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (addRotation,Space.World);
	}
}
