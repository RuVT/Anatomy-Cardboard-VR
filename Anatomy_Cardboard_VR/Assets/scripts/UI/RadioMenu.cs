using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class RadioMenu : MonoBehaviour {
	public static RadioMenu Instance;
	public float buttonNum;
	public RadioButton buttonPref;
	public RadioButton selected;
	private Vector3 distance;
	public int mult;
	// Use this for initialization
	void Start () {
		SetActive (false);
		Instance = this;
		distance = GvrViewer.Instance.HeadPose.Position - transform.position;
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveToCameraCenter(){
		Quaternion head = GvrViewer.Controller.Head.transform.rotation;
		var dis = GvrViewer.Controller.Head.transform.forward * mult;
		transform.parent.position = GvrViewer.Instance.transform.position + dis;
		transform.parent.rotation = head;
	}

	public void SetActive(bool activate){
		transform.parent.gameObject.SetActive (activate);
	}
}
