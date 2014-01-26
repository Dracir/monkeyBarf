using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
	
	Light[] lights;
	
	float onFor = 0.3f;
	float offFor = 0.2f;
	float timer;
	bool on;
	bool flickering;
	
	public bool Flickering {
		get { return flickering; }
		set { flickering = value; }
	}
	
	// Use this for initialization
	void Awake () {
		lights = FindObjectsOfType (typeof(Light)) as Light[];
		flickering = true;
	}
	
	void Start(){
	}
	
	// Update is called once per frame
	void Update () {
		if (!flickering) return;
		timer += Time.deltaTime;
		if (on && timer >= onFor){
			on = false;
			timer = 0;
			foreach (Light light in lights){
				light.enabled = false;
			}
		}
		else if(!on && timer >= offFor) {
			on = true;
			timer = 0;
			foreach (Light light in lights) {
				light.enabled = true;
			}
		}
	}
	
	void StartFlickering(){
		flickering = true;
	}
	
}
