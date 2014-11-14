using UnityEngine;
using System.Collections;

public class EnergyMeter : MonoBehaviour {
	
	public int max = 100;
	public float current = 50.0f;
	
	private int width = 100;
	private Texture2D texture;
	private Color32 color;
	
	void Start () {
		color = new Color32(60, 170, 210, 255);
		texture = new Texture2D(1,1);
		texture.SetPixel(1,1, color);
		texture.Apply();
	}
	
	void Update () {
		current -= 0.1f;
		current = Mathf.Max (0, current);
	}
	
	void OnGUI() {
		GUI.DrawTexture(new Rect(100, 10, current, 1), texture);
	}
}
