using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour {

	private Animator _animator;
	private ParticleSystem _smoke;
	
	public bool on = false;

	void Start () {

		GameObject flame = GameObject.Find("Flame");
		
		_animator = flame.GetComponent<Animator>();
	}
	
	void Update () {
	
		if(on) {
			_animator.SetBool("jetpack-on", true);
		} else {
			_animator.SetBool("jetpack-on", false);
		}
	
	}
}
