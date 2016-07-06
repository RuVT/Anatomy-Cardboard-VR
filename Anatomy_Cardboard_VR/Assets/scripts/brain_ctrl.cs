using UnityEngine;
using System.Collections;

public class brain_ctrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var rot = GvrViewer.Instance.HeadPose.Orientation;
		this.transform.localRotation = rot;
	}
}
