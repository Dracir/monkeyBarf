using UnityEngine;
using System.Collections;

public class ShotCaller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void execute(string functionName, string param){
		if (functionName.Equals ("debugFloat")) {
			float number = float.Parse(param);
			debugFloat(number);
		}
	}

	public void debugFloat(float number){
		Debug.Log (number);
	}
}
