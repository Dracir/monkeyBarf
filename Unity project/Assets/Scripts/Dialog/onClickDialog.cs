using UnityEngine;
using System.Collections;

public class onClickDialog : MonoBehaviour {

	private CharacterDialog characterDialog;


	void Start () {
		characterDialog = (CharacterDialog)this.transform.parent.parent.GetComponent<CharacterDialog> ();
	}


	void OnMouseDown()  { 
		characterDialog.startDialog ();
	}
}
