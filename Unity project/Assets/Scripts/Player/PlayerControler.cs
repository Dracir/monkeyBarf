using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	private GameObject fpsGameObject;
	private MouseLook mouseLookX;

	private GameObject cameraGameObject;
	private Camera camera;
	private MouseLook mouseLookY;

	private GameObject attachedTo;

	private CharacterController characterController;

	void Start () {
		fpsGameObject = this.transform.FindChild ("First Person Controller").gameObject;
		characterController = (CharacterController) fpsGameObject.GetComponent<CharacterController> ();
		mouseLookX = (MouseLook) fpsGameObject.GetComponent<MouseLook> ();
		cameraGameObject = fpsGameObject.transform.FindChild ("Main Camera").gameObject;
		camera = (Camera) cameraGameObject.GetComponent<Camera> ();
		mouseLookY = (MouseLook) cameraGameObject.GetComponent<MouseLook> ();
	}


	void Update () {
		if (attachedTo != null) {
					
		}
	}

	public void fix(Transform transform){
		mouseLookX.enabled = false;
		mouseLookY.enabled = false;
		camera.transform.LookAt (transform.position);
		fpsGameObject.SendMessage ("SetControllable", false);
	}

	public void stopFixing(){
		mouseLookX.enabled = true;
		mouseLookY.enabled = true;
		fpsGameObject.SendMessage ("SetControllable", true);
	}

	public void setJumpHeight(float height){
		fpsGameObject.SendMessage ("SetJumpHeight", height);
	}

	
	public void attachTo(AdultControler adultControler){
		this.attachedTo = adultControler.gameObject;
	}
}
