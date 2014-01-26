using UnityEngine;
using System.Collections;

public class Hands : MonoBehaviour {
	
	Rigidbody objectHolding;
	Transform t;
	float holdOffset = 1.5f;
	float checkDistance = 8f;
	new Transform camera;
	float throwForceMultiplier = 20f;

	Vector3 lastObjectPosition;
	// Use this for initialization
	void Start () {
		t = transform;
		GameObject cameraObject = GameObject.FindWithTag ("MainCamera");
		camera = cameraObject.transform;
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		//check for objects
		if (Input.GetMouseButtonDown(0)){
			Ray ray = new Ray(camera.position, camera.forward);
			RaycastHit hitInfo;
			bool hit = Physics.Raycast (ray, out hitInfo, checkDistance);
			if (hit){
				if (hitInfo.rigidbody){
					Debug.Log ("thing has rigidbody");
					objectHolding = hitInfo.rigidbody;
					objectHolding.isKinematic = true;
				}
				
			}
		}
		
		
		//put the object in its place
		if (objectHolding != null){
			Vector3 compensation = objectHolding.transform.position - objectHolding.collider.bounds.center;
			float adjustedOffset = holdOffset + objectHolding.collider.bounds.extents.z * objectHolding.transform.localScale.z;
			Vector3 holdPosition = Vector3.Lerp (t.position + t.forward * adjustedOffset, camera.position + camera.forward * adjustedOffset, 0.5f) + compensation;
			
			objectHolding.transform.position = holdPosition;
			objectHolding.transform.rotation = Quaternion.LookRotation(camera.forward, camera.up);
			
			//set object velocity if clicked
			if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)){
				objectHolding.isKinematic = false;
				objectHolding.velocity = (holdPosition - lastObjectPosition) * throwForceMultiplier;
				objectHolding = null;
			}
			else{
				lastObjectPosition = objectHolding.transform.position;
			}
		}
	}
	
	void LateUpdate(){
		
	}
	
	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, transform.position + transform.forward * checkDistance);
	}
}
