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
		if (dialogFile == null) {
			Debug.LogError ("Character without dialogfile");		
		} else {
			DialogLoader.Load (dialogFile, this);
			//printDialogTree();
		}
		
		//dialogSystem.startDialogWith (this);
	}

	private void printDialogTree(){
		foreach (Openner o in openners) {
			Debug.Log(o.GetType().Name);
			printDialogTree(o.nextDialog);
		}
	}

	private void printDialogTree(Dialog dialog){
		if (dialog == null)return;
		if (dialog is Question) {
			Debug.Log(dialog.GetType().Name);
			Question question = (Question)dialog;
			foreach (Answer a in question.answers) {
				Debug.Log(a.GetType().Name);
				printDialogTree(a.nextDialog);
			}
		} else {
			Debug.Log(dialog.GetType().Name);
			printDialogTree(dialog.nextDialog);
		}
	}


	void Update () {
	
	}


	public void startDialog()  { 
		dialogSystem.startDialogWith (this);
	}

	public bool hasActiveOpenner(){
		foreach (Openner o in openners) {
			if(o.active) return true;	
		}
		return false;
	}

	public Openner[] getActiveOpenner(){
		List<Openner> list = new List<Openner> ();
		foreach (Openner o in openners) {
			if(o.active){
				list.Add(o);
			}
		}
		return list.ToArray ();
	}

	public void activate(string tag){
		foreach (Openner o in openners) {
			if(o.tag.Equals(tag)){
				o.active = true;
			}
		}
	}
}
