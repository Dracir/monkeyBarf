using UnityEngine;
using System.Collections;

public class AdultControler : MonoBehaviour {

	private CharacterDialog dialog;
	private GameObject overHeadNameGameObject;
	private TextMesh overHeadName;
	private NavMeshAgent agent;

	public float nextMovingTime = 0;
	public StandingSpot spot;
	public bool arrivedToSpot = false;


	void Awake () {
		dialog = this.GetComponent<CharacterDialog> ();
		overHeadNameGameObject = this.gameObject.transform.FindChild ("CharacterName").gameObject;
		overHeadName = (TextMesh) overHeadNameGameObject.GetComponent<TextMesh>();
		agent = (NavMeshAgent)this.GetComponent<NavMeshAgent> ();
	}


	void Update () {
		if (spot != null) {
			if(!arrivedToSpot){
				if(distanceToSpot() < 1){
					arrivedToSpot = true;
					this.agent.SetDestination(this.transform.position);
					StandingSpot lookAtSpot = this.spot.getRandomCanLookAtStop();
					if(lookAtSpot != null){
						this.transform.LookAt(lookAtSpot.transform.position);
					}else{
						this.transform.LookAt(new Vector3(Random.Range(-1000,1000),0,Random.Range(-1000,1000)));
					}

				}
			} else{

			}	
		}
	}

	public void activateTag(string tag){
		this.dialog.activate (tag);
	}

	public void setName(string name){
		dialog.name = name;
		overHeadName.text = name;
	}

	public string getName(){
		return dialog.name;
	}

	public void showName(){
		overHeadNameGameObject.SetActive (true);
	}

	public void hideName(){
		overHeadNameGameObject.SetActive (false);
	}

	public void goTo(StandingSpot targetSpot){
		this.spot = targetSpot;
		this.arrivedToSpot = false;
		this.agent.SetDestination (targetSpot.transform.position);
	}

	private float distanceToSpot(){
		Vector3 v = this.transform.position - this.spot.transform.position;
		return v.magnitude;
	}


}
