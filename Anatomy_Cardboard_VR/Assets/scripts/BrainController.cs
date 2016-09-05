using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BrainController : MonoBehaviour {

	public static BrainController instance;
	public bool trackOrientation = true;
	public Vector3 addRotation { get; set;}
	public float rotationRate;
	public float zoomPercentage;
	private Vector3 INIT_POS;
	private Quaternion INIT_ROT;
	private Vector3 INIT_DIS;
	public static HashSet<GameObject> itemsVisible;
	public static HashSet<GameObject> itemsSelected;
	public static GameObject lastSelection;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			INIT_POS = transform.position;
			INIT_ROT = transform.rotation;
			INIT_DIS = transform.position - GvrViewer.Instance.transform.position;
			zoomPercentage = 1;
			rotationRate = 1;
			itemsVisible = new HashSet<GameObject> ();
			itemsSelected = new HashSet<GameObject> ();

		} else {
			BrainController.Destroy (this);
		}
		foreach(Transform child in transform)
		{
			child.gameObject.AddComponent (typeof(MeshCollider));
			child.gameObject.AddComponent (typeof(BrainItemCtrl));
		}
		rotationRate = 1.0f;
	}

	void SetRotationPanel(){
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (addRotation * rotationRate,Space.World);
		Vector3 actualDis = transform.position - GvrViewer.Instance.transform.position;
		transform.position = GvrViewer.Instance.transform.position + actualDis * zoomPercentage;
	}
}
