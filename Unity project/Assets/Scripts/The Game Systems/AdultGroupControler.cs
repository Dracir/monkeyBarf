using UnityEngine;
using System.Collections;

public class AdultGroupControler : MonoBehaviour {

	private GameObject[] adults;
	private AdultControler[] adultControlers;

	void Start () {
		adults = GameObject.FindGameObjectsWithTag ("adult");
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

	public void activateTag(string tag){
		foreach (AdultControler adult in adultControlers) {
			adult.activateTag(tag);
		}
	}

	public AdultControler getAdultWithName(string name){
		foreach (AdultControler adult in adultControlers) {
			if(adult.getName().Equals(name)){
				return adult;
			}
		}
		return null;
	}
}

