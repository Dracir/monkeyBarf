using UnityEngine;
using System.Collections;

public class StandingSpot : MonoBehaviour {

	public GameObject adultInTheSpot;

	public bool isEmpty(){
		return this.adultInTheSpot == null;
	}

}
