using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BrainItemCtrl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

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
		bool selected = BrainController.itemsSelected.Contains(gameObject);
		bool lastSelected = BrainController.lastSelection == gameObject;
		GetComponent<Renderer>().material.color = selected ? Color.red : (lastSelected ? Color.green : OROGINAL);
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		//SetGazedAt (true);
		BrainController.lastSelection = gameObject;
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		//SetGazedAt (false);
	}

}
