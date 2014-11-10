using UnityEngine;
using System.Collections;

public class FlameController : MonoBehaviour {

	PlayerInputController _playerInput;
	Animator _animator;

	void Awake()
	{
		_playerInput = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerInputController>();
		_animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(_playerInput.isBoosting) {
			_animator.SetBool("boosting", true);
		} else {
			_animator.SetBool("boosting", false);
		}
	
	}
}
