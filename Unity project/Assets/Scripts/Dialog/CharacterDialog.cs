using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterDialog : MonoBehaviour {

	public TextAsset dialogFile;

	public string brushOff;
	public string characterName;
	public List<Openner> openners;

	private DialogSystem dialogSystem;

	void Start () {
		dialogSystem = GameObject.FindGameObjectWithTag ("TheGame").GetComponent<DialogSystem> ();
		DialogLoader.Load (dialogFile, this);
		
		dialogSystem.startDialogWith (this);
	}


	void Update () {
	
	}


	void OnMouseDown()  { 
		dialogSystem.startDialogWith (this);
	}
}
