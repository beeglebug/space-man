using UnityEngine;
using System.Collections;

public class EnergyMeter : Meter {

	public float depletionRate = 0.6f;
	public float rechargeRate = 0.3f;
	
	public bool isDepleting = false;
	
	public void Start () {
		color = new Color32(255,212,85,255);
		position.Set(100,30);
		base.Start ();
	}
	
	void Update() {
		
		if(isDepleting) {
			current -= depletionRate;
		} else {
			current += rechargeRate;
		}
		
		current = Mathf.Clamp(current, min, max);
		
	}
	
}
