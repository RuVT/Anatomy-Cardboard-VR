using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;


#if UNITY_EDITOR
public class CustomRadialMenuWindow : EditorWindow {
	float int_radio = 100, ext_radio = 200;
	float start_angle = 0.0f;
	float margin = 5.0f;
	int button_num = 6;
	[MenuItem("RadialMenu/Create")]
	public static void ShowWindow(){
		EditorWindow.GetWindow<CustomRadialMenuWindow> ();
	}

	void OnGUI(){
//		if (baseButton == null)
//			GetBaseButton ();
		
		GUILayout.Label ("Radial Menu Settings", EditorStyles.boldLabel);
		int_radio = EditorGUILayout.Slider("Internal radio", int_radio, 0, 200);
		//ext_radio = EditorGUILayout.Slider ("External radio", ext_radio,0, 100);
		start_angle = EditorGUILayout.FloatField ("Start angle", start_angle);
		margin = EditorGUILayout.FloatField ("Margin", margin);
		button_num = EditorGUILayout.IntField ("Number of buttons", button_num);

		Rect myRect = EditorGUILayout.GetControlRect (false,400.0f, GUILayout.ExpandWidth(false));
		RefreshRadialMenuSprite (myRect.x, myRect.y, 400.0f, 400.0f);

		if(GUILayout.Button("Add Radial Menu")){
			CreateRadialMenu ();
		}
	}

	public static void DrawTexture(Rect position, Sprite sprite, Vector2 size){
		Rect spriteRect = new Rect(sprite.rect.x/sprite.texture.width, sprite.rect.y/sprite.texture.height,  sprite.rect.width / sprite.texture.width, sprite.rect.height / sprite.texture.height);
		Vector2 actualSize = size;
		actualSize.y *= (sprite.rect.height / sprite.rect.width);
		Graphics.DrawTexture(new Rect(position.x, position.y + (size.y - actualSize.y) / 2, actualSize.x, actualSize.y), sprite.texture, spriteRect, 0, 0, 0, 0);
	}

	public static void DrawTextureGUI(Rect position, Sprite sprite, Vector2 size)
	{
		Rect spriteRect = new Rect(sprite.rect.x / sprite.texture.width, sprite.rect.y / sprite.texture.height,
			sprite.rect.width / sprite.texture.width, sprite.rect.height / sprite.texture.height);
		Vector2 actualSize = size;

		actualSize.y *= (sprite.rect.height / sprite.rect.width);
		GUI.DrawTextureWithTexCoords(new Rect(position.x, position.y + (size.y - actualSize.y) / 2, actualSize.x, actualSize.y), sprite.texture, spriteRect);
	}

	public RadialButton GetRadialButton(){
		Object prefab = AssetDatabase.LoadAssetAtPath ("Assets/prefabs/RadialButton.prefab", typeof(GameObject));
		if (prefab == null)
			Debug.Log ("prefab is null");
		GameObject baseButton = Instantiate (prefab, Vector3.zero, Quaternion.identity) as GameObject;
		if (baseButton == null)
			Debug.Log ("Button is null");
		RadialButton radialButton = baseButton.GetComponent<RadialButton> ();
		if (radialButton == null)
			Debug.Log ("Radial buttom is null");
		return radialButton;
	}

	public GameObject GetCanvas(){
		Object prefab = AssetDatabase.LoadAssetAtPath ("Assets/prefabs/RadialMenuCanvas.prefab", typeof(GameObject));
		GameObject canvas = (Instantiate (prefab, Vector3.zero, Quaternion.identity) as GameObject);
		return canvas;
	}

	public void RefreshRadialMenuSprite(float x, float y, float w, float h){
		Sprite sprite = RadialShapeSprite.GenerateRadialShape (start_angle, 360.0f, int_radio, ext_radio);
		DrawTextureGUI (new Rect (x, y, 100.0f, 100.0f), sprite, sprite.rect.size);
	}

	public void CreateRadialMenu(){
		GameObject canvas = GetCanvas ();
		GameObject menu = canvas.transform.GetChild (0).gameObject;
		float midMargin = margin / 2.0f;
		float angle = 360.0f / button_num;
		for (int n = 0; n < button_num; n++) {
			RadialButton button = GetRadialButton ();
			button.transform.SetParent (menu.transform);
			float deg_i = (start_angle + (angle * n) + midMargin) % 360;
			float deg_f = (start_angle + (angle * (n + 1)) - midMargin) % 360;

			button.GenerateRadialShape (deg_i, deg_f, int_radio, ext_radio);
		}
	}

	// Use this for initialization
	void Start () {
		//baseButton = AssetDatabase.LoadAssetAtPath("Assets/prefabs/RadioButton",typeof(GameObject));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
#endif