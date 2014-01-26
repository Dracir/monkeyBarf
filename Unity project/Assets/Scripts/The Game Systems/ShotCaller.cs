using UnityEngine;
using System.Collections;

public class ShotCaller : MonoBehaviour {

	private AdultGroupControler adultGroupControler;


	void Start () {
		adultGroupControler = (AdultGroupControler)this.gameObject.GetComponent<AdultGroupControler> ();
	}


	void Update () {
	
	}


	public void execute(string functionName, string param){
		if (functionName.Equals ("debugFloat")) {
			float number = float.Parse(param);
			debugFloat(number);
		}else if (functionName.Equals ("removeNames")) {
			adultGroupControler.removeAllNames();
		}
	}

	public void debugFloat(float number){
		Debug.Log (number);
	}
}
