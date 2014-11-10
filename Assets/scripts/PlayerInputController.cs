using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour
{
	public float gravity = -25f;
	public float runSpeed = 4f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float boostStrength = 3f;

	public bool isBoosting = false;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private RayCastCollider2D _collider;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;

	private KeyCode boostKey = KeyCode.Space;

	void Awake()
	{
		//_animator = GetComponent<Animator>();
		_collider = GetComponent<RayCastCollider2D>();
	}
	
	void Update()
	{
		// grab our current _velocity to use as a base for all calculations
		_velocity = _collider.velocity;

		if( _collider.isGrounded )
		{
			_velocity.y = 0;
		}

		bool xAxisDown = false;
		bool yAxisDown = false;
		
		normalizedHorizontalSpeed = 0;
		
		if( Input.GetKey( KeyCode.RightArrow ) )
		{
			xAxisDown = true;
			normalizedHorizontalSpeed = 1;
			if( transform.localScale.x < 0f ) {
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			}
		}
		
		if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			xAxisDown = true;
			normalizedHorizontalSpeed = -1;
			if( transform.localScale.x > 0f ) {
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			}
			
		}

		var smoothedMovementFactor = _collider.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?

		if( Input.GetKey( boostKey ) )
		{
			_velocity.y = Mathf.Lerp( _velocity.y, boostStrength, Time.deltaTime * smoothedMovementFactor );
			isBoosting = true;
		} else {
			isBoosting = false;
		}

		// apply horizontal speed smoothing it
		
		_velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );
	
		_velocity.y += gravity * Time.deltaTime;

		_collider.move( _velocity * Time.deltaTime );
		
		// set animator flags
		//_animator.SetBool( "onGround", _collider.isGrounded );
		//_animator.SetFloat( "velocityX", Mathf.Abs(_velocity.x));
		//_animator.SetFloat( "velocityY", _velocity.y);
		//_animator.SetBool( "xAxisDown", xAxisDown);
		//_animator.SetBool( "yAxisDown", yAxisDown);
		
		
	}

}
