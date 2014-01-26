using UnityEngine;
using System.Collections;

public class CloneOrDestroy : MonoBehaviour {
	public Vector3 cloneOffset = new Vector3(10, 0, 10);
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Clone (){
		GameObject.Instantiate((Object) gameObject, transform.position + cloneOffset, transform.rotation);
	}
	
	void Destroy (){
		gameObject.SetActive(false);
	}
}
