using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class RadialMenu : MonoBehaviour {
	public static Dictionary<string, RadialMenu> menus;
	public string menuName;
	private Vector3 distance;
	public int mult;
	// Use this for initialization

	protected virtual void Awake()
	{
		if (menus == null) {
			menus = new Dictionary<string, RadialMenu>();
		}
		mult = 3;
	}

	void Start () {
		SetActive (false);
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
		gameObject.SetActive (activate);
		transform.parent.gameObject.SetActive (activate);
	}
}
