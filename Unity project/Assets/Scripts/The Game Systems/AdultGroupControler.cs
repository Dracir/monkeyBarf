using UnityEngine;
using System.Collections;

public class AdultGroupControler : MonoBehaviour {

	private GameObject[] adults;
	private AdultControler[] adultControlers;

	void Start () {
		adults = GameObject.FindGameObjectsWithTag ("Adult");
		adultControlers = new AdultControler[adults.Length];
		int index = 0;
		foreach (GameObject adult in adults) {
			adultControlers[index++] = (AdultControler) adult.GetComponent<AdultControler>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void removeAllNames(){
		foreach (AdultControler adult in adultControlers) {
			adult.hideName();
		}
	}

	public void showAllNames(){
		foreach (AdultControler adult in adultControlers) {
			adult.showName();
		}
	}
}

