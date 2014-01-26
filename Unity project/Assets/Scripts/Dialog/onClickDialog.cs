using UnityEngine;
using System.Collections;

public class onClickDialog : MonoBehaviour {

	private CharacterDialog characterDialog;
	float checkDistance = 5f;
	
	void Start () {
		characterDialog = (CharacterDialog)this.transform.parent.GetComponent<CharacterDialog> ();
	}

	void Update (){
		
		if (Input.GetMouseButtonDown(0) && !characterDialog.dialogSystem.character){
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;
			bool hit = Physics.Raycast (ray, out hitInfo, checkDistance);
			if (hit){
				if (hitInfo.collider == this.collider){
					Screen.lockCursor = false;
					characterDialog.startDialog();
				}
				
			}
		}
		
	}
	void OnMouseDown()  { /*
		Screen.lockCursor = false;
		characterDialog.startDialog ();*/
	}
}
