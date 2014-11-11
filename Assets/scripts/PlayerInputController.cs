using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour
{
	public float boostSpeed = 20f;
	public float horizontalSpeed = 10f;
	public bool isBoosting = false;
	
	void FixedUpdate()
	{		
		isBoosting = false;
		
		if( Input.GetKey( KeyCode.RightArrow ) )
		{
			rigidbody2D.AddForce(new Vector2(horizontalSpeed, 0));
			
			if( transform.localScale.x < 0f ) {
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			}
		}
		
		if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			rigidbody2D.AddForce(new Vector2(-horizontalSpeed, 0));
			
			if( transform.localScale.x > 0f ) {
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			}
			
		}

		if( Input.GetKey( KeyCode.Space ) )
		{
			rigidbody2D.AddForce(new Vector2(0, boostSpeed));
			isBoosting = true;
		}
		
		rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, 10);
		
	}
}
