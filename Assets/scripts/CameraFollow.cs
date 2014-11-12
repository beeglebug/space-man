using UnityEngine;
using System.Collections;
//using UnityEditor;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float xSmooth = 5f;
	public float ySmooth = 5f;
   
	void Awake () {}

	void Update () {
		TrackTarget ();
    }

	public void TrackTarget() {

		float targetX = target.transform.position.x;
		float targetY = target.transform.position.y;

		targetX = Mathf.Lerp (transform.position.x, target.transform.position.x, xSmooth * Time.deltaTime);
		targetY = Mathf.Lerp (transform.position.y, target.transform.position.y, ySmooth * Time.deltaTime);
	
		transform.position = new Vector3(targetX, targetY, transform.position.z);

    }    
}
