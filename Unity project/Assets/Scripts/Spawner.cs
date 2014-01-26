using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Spawn(string param){
		Object toLoad = Resources.Load ("Models/" + param);
		Instantiate(toLoad, transform.position, transform.rotation);
	}
	
	void OnDrawGizmos (){
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position, 0.1f);
	}
	
}
