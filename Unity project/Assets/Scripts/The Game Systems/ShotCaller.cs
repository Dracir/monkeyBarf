using UnityEngine;
using System.Collections;

public class ShotCaller : MonoBehaviour {

	private AdultGroupControler adultGroupControler;
	private PlayerControler playerControler;


	void Start () {
		adultGroupControler = (AdultGroupControler)this.gameObject.GetComponent<AdultGroupControler> ();
		playerControler = (PlayerControler)GameObject.FindGameObjectWithTag ("ThePlayer").GetComponent<PlayerControler> ();
		
		Animator[] animators = FindObjectsOfType(typeof(Animator)) as Animator[];
		foreach (Animator item in animators) {
			item.playbackTime = Random.Range(0, 6f);
		}
	}


	void Update () {
	
	}


	public void execute(string functionName, string tag, string param){
		if (functionName.Equals ("debugFloat")) {
			float number = float.Parse(param);
			debugFloat(number);
		}else if (functionName.Equals ("removeNames")) {
			adultGroupControler.removeAllNames();
		}else if (functionName.Equals ("SetJumpHeight")) {
			float number = float.Parse(param);
			playerControler.setJumpHeight(number);
		}else if (functionName.Equals ("scaleObject")) {
			float number = float.Parse(param);
			GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

			foreach (GameObject o in objects) {
				o.transform.localScale *= number;
			}
		}else if (functionName.Equals ("rotateX")) {
			float number = float.Parse(param);
			GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
			
			foreach (GameObject o in objects) {
				o.transform.Rotate (Vector3.right, number);
			}
		}else if (functionName.Equals ("rotateY")) {
			float number = float.Parse(param);
			GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
			
			foreach (GameObject o in objects) {
				o.transform.Rotate (Vector3.up, number);
			}
		}else if (functionName.Equals ("rotateZ")) {
			float number = float.Parse(param);
			GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
			
			foreach (GameObject o in objects) {
				o.transform.Rotate (Vector3.forward, number);
			}
		}else if (functionName.Equals ("color")) {
			Renderer[] renderers = FindObjectsOfType(typeof(Renderer)) as Renderer[];
			foreach (Renderer item in renderers) {
				Color color;
				if(param.Equals("chartreuse")){
					color = new Color(147f/255f, 200f/255f, 49f/255f, 1f);
				}else if (param.Equals ("pink")){
					color = new Color(254f/255f, 160f/255f, 196f/255f, 1f);
				}else if (param.Equals ("blue")){
					color = Color.blue;
				}else {
					color = Color.magenta;
				}
				item.material.color = color;
			}
		}else if (functionName.Equals ("attachTo")) {
			AdultControler adult = adultGroupControler.getAdultWithName(param);
			playerControler.attachTo(adult);
		}else if (functionName.Equals ("setAnimationTimeScale")){
			Animator[] animators = FindObjectsOfType(typeof(Animator)) as Animator[];
			foreach (Animator item in animators) {
				item.speed = float.Parse (param);
			}
		}
	}

	public void debugFloat(float number){
		Debug.Log (number);
	}
}
