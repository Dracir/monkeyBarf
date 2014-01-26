using UnityEngine;
using System.Collections;

public class StandingSpot : MonoBehaviour {

	[HideInInspector]
	public GameObject adultInTheSpot;
	public StandingSpot[] canLookAt;

	public bool isEmpty(){
		return this.adultInTheSpot == null;
	}

	public StandingSpot getRandomCanLookAtStop(){
		if (canLookAt.Length == 0) return null;
		if (allSpotsEmpty ()) {
			int rnd = Random.Range(0, canLookAt.Length);
			return canLookAt[rnd];
		} else {
			while(true){
				int rnd = Random.Range(0, canLookAt.Length);
				StandingSpot spot = canLookAt[rnd];
				if(!spot.isEmpty()){
					return spot;
				}
			}
		}
	}

	public bool allSpotsEmpty(){
		foreach (StandingSpot spot in canLookAt) {
			if(!spot.isEmpty())	return false;
		}
		return true;
	}
}
