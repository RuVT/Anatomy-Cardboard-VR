using UnityEngine;
using System.Collections;

public class change_color_ctrl : MonoBehaviour {

	private Color OROGINAL;
	// Use this for initialization
	void Start () {
		OROGINAL = GetComponent<Renderer> ().material.color;
	}

	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : OROGINAL;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
