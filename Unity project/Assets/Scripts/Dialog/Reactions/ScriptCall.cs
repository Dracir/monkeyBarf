using UnityEngine;
using System.Collections;

public class ScriptCall : Dialog {

	public string script;
	public string tag;
	public string param;
	
	public ScriptCall(string script,string tag, string param){
		this.script = script;
		this.tag = tag;
		this.param = param;
	}
}
