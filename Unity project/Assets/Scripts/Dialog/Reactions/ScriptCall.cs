using UnityEngine;
using System.Collections;

public class ScriptCall : Dialog {

	public string script;
	public string param;
	
	public ScriptCall(string script,string param){
		this.script = script;
		this.param = param;
	}
}
