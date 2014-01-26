using UnityEngine;
using System.Collections;

public class AdultControler : MonoBehaviour {

	private CharacterDialog dialog;
	private GameObject overHeadNameGameObject;
	private TextMesh overHeadName;
	private NavMeshAgent agent;

	public float nextMovingTime = 0;
	public StandingSpot spot;

	// Use this for initialization
	void Awake () {
		dialog = this.GetComponent<CharacterDialog> ();
		overHeadNameGameObject = this.gameObject.transform.FindChild ("CharacterName").gameObject;
		overHeadName = (TextMesh) overHeadNameGameObject.GetComponent<TextMesh>();
		agent = (NavMeshAgent)this.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	
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
		this.agent.SetDestination (targetSpot.transform.position);
	}

}
