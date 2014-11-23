using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {
	
	public int min = 0;
	public int max = 99;
	public float current;
	
	public Color32 color = new Color32(60, 170, 210, 255);
	public Vector2 position;
	
	protected Texture2D _texture;
	
	public void Start () {
		current = (float)max;
		_texture = new Texture2D(1,1);
		_texture.SetPixel(1,1, color);
		_texture.Apply();
	}
	
	void OnGUI() {
		GUI.DrawTexture(new Rect(position.x, position.y, current, 2), _texture);
		GUI.Label(new Rect(position.x - 30, position.y, 30,20), current.ToString());
	}
}
