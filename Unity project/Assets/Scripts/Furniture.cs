﻿using UnityEngine;
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
	}
	
	public void ChangeColour(Color newColor){
		renderer.material.color = newColor;
	}
}