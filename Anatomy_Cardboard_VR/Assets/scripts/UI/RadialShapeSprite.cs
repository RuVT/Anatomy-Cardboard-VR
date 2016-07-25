using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class RadialShapeSprite : MonoBehaviour {
	public GameObject button;
	public float deg_i, deg_f, ri, re;
	public int size;

	public Texture2D GetShape(float deg_i, float deg_f, float ri, float re){
		Texture2D shape = new Texture2D (size, size, TextureFormat.Alpha8, false);

//		shape.alphaIsTransparency = true;
//		shape.Apply ();

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
					double angY = 0, angX = 0;
					angY = Mathf.Asin((y - center.y) / d2)*(180/Mathf.PI);
					angX = Mathf.Acos((x - center.x) / d2)*(180 / Mathf.PI);
					if (x - center.x < 0)
						angY = 180 - angY;
					else if (y - center.y < 0)
						angY = 360 + angY;
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

		texture.SetPixels (pixels);

		texture.Apply ();

		byte[] data = texture.EncodeToPNG ();
		File.WriteAllBytes (Application.dataPath + "/testimagen.png", data);
		return shape;
	}
}
