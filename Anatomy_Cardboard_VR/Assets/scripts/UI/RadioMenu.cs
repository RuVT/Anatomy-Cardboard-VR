using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadioMenu : MonoBehaviour {
	public float buttonNum;
	public RadioButton buttonPref;
	public RadioButton selected;
	// Use this for initialization
	void Start () {
		float deg = 360.0f / buttonNum;
		for (int n = 0; n < buttonNum; n++) {
			RadioButton button = Instantiate (buttonPref) as RadioButton;
			button.GenerateRadialShape (deg * n, deg * (n + 1), 100, 200);
			button.transform.SetParent(transform, false);
		}
		UnityEditor.PrefabUtility.CreatePrefab ("Assets/prefabs/test.prefab", gameObject);//UnityEditor.ReplacePrefabOptions.ReplaceNameBased);
		//PlayerPrefs.Save ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
