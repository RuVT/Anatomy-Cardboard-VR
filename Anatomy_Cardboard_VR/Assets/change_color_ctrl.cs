using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class change_color_ctrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

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

	public void OnPointerDown(PointerEventData eventData){
		GetComponent<Renderer> ().material.color = Color.green;
	}

	public void OnPointerUp(PointerEventData eventData){
		GetComponent<Renderer> ().material.color = OROGINAL;
	}
}
