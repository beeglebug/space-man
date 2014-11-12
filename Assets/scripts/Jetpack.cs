using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour {

	Animator _animator;
	public bool on = false;

	// Use this for initialization
	void Start () {
		GameObject flame = GameObject.Find("Flame");
		_animator = flame.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(on) {
			_animator.SetBool("jetpack-on", true);
		} else {
			_animator.SetBool("jetpack-on", false);
		}
	
	}
}
