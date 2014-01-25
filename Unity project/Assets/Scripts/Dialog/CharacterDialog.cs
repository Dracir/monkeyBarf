using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterDialog : MonoBehaviour {

	public TextAsset dialogFile;

	public string brushOff;
	public string characterName;

	public List<Openner> openners;

	void Start () {
		DialogLoader.Load (dialogFile, this);
	}


	void Update () {
	
	}


	void OnMouseDown()  { 
		Debug.Log (this.brushOff);
	}
}
