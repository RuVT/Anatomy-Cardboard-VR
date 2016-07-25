using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class RadioButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	private Color OROGINAL;
	// Use this for initialization
	void Start () {
		//OROGINAL = GetComponent<CanvasRenderer> ().GetMaterial().color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateRadialShape(float deg_i, float deg_f, float ri, float re){
		Texture2D shape = new Texture2D (400, 400);
		float ri2 = Mathf.Pow(ri, 2.0f);
		float re2 = Mathf.Pow(re, 2.0f);
		float rad_i = deg_i * (Mathf.PI / 180);
		float rad_f = deg_f * (Mathf.PI / 180);
		Vector2 center = new Vector2(shape.width / 2.0f, shape.height / 2.0f);
		int minX=shape.width, minY=shape.height, maxX=0, maxY=0;
		for (int x = 0; x <= shape.width-1; x++)
		{
			for (int y = 0; y <= shape.height-1; y++)
			{
				float d2 = Mathf.Pow(x - center.x, 2.0f) + Mathf.Pow(y - center.y, 2.0f);
				if (ri2 <= d2 && d2 <= re2)
				{
					d2 = Mathf.Sqrt(d2);

					float angY = GetAngle (x, y, center.x, center.y, d2);
					if (deg_i <= angY && angY <= deg_f)
					{
						shape.SetPixel(x,y, Color.white);
						if (x < minX)
							minX = x;
						if (y < minY)
							minY = y;
						if (x > maxX)
							maxX = x;
						if (y > maxY)
							maxY = y;
					}
					else
						shape.SetPixel(x,y, Color.clear);  
				}
				else
					shape.SetPixel(x,y, Color.clear);
			}
		}
		Color [] pixels = shape.GetPixels (minX, minY, maxX - minX, maxY - minY);
		Texture2D texture = new Texture2D(maxX-minX, maxY-minY);
		Sprite temp = Sprite.Create (texture, new Rect (0,0, texture.width, texture.height), new Vector2(0.5f,0.5f),100);
		gameObject.GetComponent<Image> ().sprite = temp;
		shape.Apply ();

		SetIconPositionAndSize (deg_i, deg_f, ri, re, minX, minY);
		SetPositionAndSize (minX, minY, maxX, maxY);

		texture.SetPixels (pixels);
		texture.Apply ();

		byte[] data = texture.EncodeToPNG ();
		File.WriteAllBytes (Application.dataPath + "/sprites/radioMenu/"+deg_i+"_deg.png", data);
	}

	private void SetPositionAndSize(int minX, int minY, int maxX, int maxY){
		GetComponent<RectTransform> ().sizeDelta = new Vector2 (maxX - minX, maxY - minY);
		GetComponent<RectTransform> ().localPosition = new Vector3 (minX, minY, 0);
	}

	private void SetIconPositionAndSize(float deg_i, float deg_f, float ri, float re, float minX, float minY){
		float mid_deg = (deg_f - deg_i) / 2.0f;
		float mid_r = ri + (re / 2.0f);
		Vector2 point = GetMidPoint (mid_deg, mid_r);
		Vector3 mid_point = new Vector3 (point.x - minX, point.y - minY, 0);
		GetComponentInChildren<RectTransform> ().localPosition = mid_point;
		mid_r = (re - ri) / 2.0f;
		float dis = mid_r * Mathf.Cos ((45.0f * (Mathf.PI / 180.0f)));
		Vector2 iconSize = new Vector2 (2 * dis, 2 * dis);
		transform.GetChild(0).GetComponent<RectTransform> ().sizeDelta= iconSize;
	}

	private float GetAngle(float x, float y, float h, float k, float r){
		float angY = 0;
		angY = Mathf.Asin((y - k) / r)*(180/Mathf.PI);
		if (x - h < 0)
			angY = 180 - angY;
		else if (y - k < 0)
			angY = 360 + angY;
		return angY;
	}

	private Vector2 GetMidPoint(float mid_deg, float r){
		float x, y;
		float rad = mid_deg * (Mathf.PI / 180.0f);
		x = r * Mathf.Cos (rad);
		y = r * Mathf.Sin(rad);
		return new Vector2 (x, y);
	}
//
//	public void AutoSetPosition(float deg_i, float deg_f, float ri, float re){
//		
//	}
	public void OnPointerEnter (PointerEventData eventData){
		
	}

	public void OnPointerExit (PointerEventData evenData){
		
	}


}
