﻿using UnityEngine;
using System.Collections;

public class GuessMovementAi : MonoBehaviour {

	
	private GameObject[] adults;
	private AdultControler[] adultControlers;
	private StandingSpot[] standingSpots;

	public int standingMinTime;
	public int standingMaxTime;


	void Start () {
		adults = GameObject.FindGameObjectsWithTag ("adult");
		standingSpots = GameObject.Find ("GuessStandingSpots").transform.GetComponentsInChildren<StandingSpot> () as StandingSpot[];
		adultControlers = new AdultControler[adults.Length];
		int index = 0;
		foreach (GameObject adult in adults) {
			adultControlers [index++] = (AdultControler)adult.GetComponent<AdultControler> ();
		}
	}



	private StandingSpot getRandomStandingSpot(){
		int trys = 0;
		StandingSpot spot = null;
		while (trys++ < 100 && spot == null) {
			int rnd = Random.Range(0, standingSpots.Length);
			spot = standingSpots [rnd];
			if(!spot.isEmpty()){
				spot = null;
			}
		}
	
		return standingSpots [0];
	}


	void Update () {
		foreach (AdultControler adult in adultControlers) {
			adult.nextMovingTime -= Time.deltaTime;
			if(adult.nextMovingTime <= 0){
				adult.nextMovingTime = Random.Range(standingMinTime,standingMaxTime);
				if(adult.spot != null){
					adult.spot.adultInTheSpot = null;
				}

				StandingSpot spot = getRandomStandingSpot();
				spot.adultInTheSpot = adult.gameObject;
				adult.goTo(spot);
			}
			
		}
	}
}