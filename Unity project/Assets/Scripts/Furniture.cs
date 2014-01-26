using UnityEngine;
using System.Collections;

public class Furniture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AddRigidbody(){
		gameObject.AddComponent<Rigidbody>();
		ChangeColour (Color.red);
	}
	
	public void ChangeColour(Color newColor){
		renderer.material.color = newColor;
	}
	
	public void ChangeModel(string replacement){
		gameObject.GetComponentInChildren<Renderer>().enabled = false;
		Collider target = collider;
		if (target == null){
			target = gameObject.GetComponentInChildren<Collider>();
		}
		GameObject newThing = Instantiate (Resources.Load ("Models/" + replacement), target.bounds.center, transform.rotation) as GameObject;
		newThing.transform.parent = transform;
	}
}
