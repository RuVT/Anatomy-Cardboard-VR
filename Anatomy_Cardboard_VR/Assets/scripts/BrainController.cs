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
			child.gameObject.AddComponent (typeof(change_color_ctrl));
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
