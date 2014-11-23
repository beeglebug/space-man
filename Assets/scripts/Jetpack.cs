using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour {

	private Animator _animator;
	private ParticleSystem _smoke;

	public float energy = 99;
	public bool on = false;

	void Start () {

		GameObject flame = GameObject.Find("Flame");
		
		_smoke = gameObject.GetComponentInChildren<ParticleSystem>();
		
		_animator = flame.GetComponent<Animator>();
		
	}
	
	void Update () {
	
		if(on) {
			if(energy > 0) {
				_animator.SetBool("jetpack-on", true);
				_smoke.enableEmission = true;
				rigidbody2D.AddForce(new Vector2(0, 20.0f));
				energy -= 0.6f;
			} else {
				_animator.SetBool("jetpack-on", false);
				_smoke.enableEmission = false;
			}
		} else {
			_animator.SetBool("jetpack-on", false);
			_smoke.enableEmission = false;
			energy += 0.3f;
		}
	
		energy = Mathf.Clamp(energy, 0, 99);
	}
	
	void OnGUI() {
		GUI.Label(new Rect( 0, 10, 30,20), energy.ToString());
		//GUI.Label(new Rect( 0, 30, 30,20), "99");
	}
}
