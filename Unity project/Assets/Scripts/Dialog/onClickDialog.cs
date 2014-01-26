using UnityEngine;
using System.Collections;

public class onClickDialog : MonoBehaviour {

	private CharacterDialog characterDialog;


	void Start () {
		characterDialog = (CharacterDialog)this.transform.parent.parent.GetComponent<CharacterDialog> ();
	}


	void OnMouseDown()  { 
		Vector3 v = this.transform.position - this.characterDialog.transform.position;
		if (v.magnitude < 5) {
			characterDialog.startDialog ();		
		}
	}

}
