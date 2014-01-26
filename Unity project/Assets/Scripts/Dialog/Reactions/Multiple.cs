using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Multiple : Dialog {

	public string text;
	
	public List<Dialog> dialogs;
	
	public Multiple(string text){
		this.text = text;
		this.dialogs = new List<Dialog> ();
	}
}
