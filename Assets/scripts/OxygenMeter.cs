using UnityEngine;
using System.Collections;

public class OxygenMeter : Meter {

	void Start() {
		color = new Color32(60, 170, 210, 255);
		position = new Vector2(100,10);
		base.Start ();
	}

}
