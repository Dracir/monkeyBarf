using UnityEngine;
using System.Collections;

public class Vibrator : MonoBehaviour {
	Quaternion initialRotation;
	float maxRotateAmount = 5f;
	Transform t;
	
	// Use this for initialization
	void Start () {
		t = transform;
		initialRotation = t.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		t.rotation = initialRotation;
		t.Rotate (Random.insideUnitSphere * Random.Range (0, maxRotateAmount));
	}
}
