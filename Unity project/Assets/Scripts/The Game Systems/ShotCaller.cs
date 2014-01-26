using UnityEngine;
using System.Collections;

public class ShotCaller : MonoBehaviour {

	private AdultGroupControler adultGroupControler;
	private PlayerControler playerControler;


	void Start () {
		adultGroupControler = (AdultGroupControler)this.gameObject.GetComponent<AdultGroupControler> ();
		playerControler = (PlayerControler)GameObject.FindGameObjectWithTag ("ThePlayer").GetComponent<PlayerControler> ();
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
				Color color = null;
				if(param.Equals("chartreuse")){
					color = new Color(147f/255f, 200f/255f, 49f/255f, 1f);
				}
				item.material.color = color;
			}
		}else if (functionName.Equals ("attachTo")) {
			AdultControler adult = adultGroupControler.getAdultWithName(param);
			playerControler.attachTo(adult);
		}
	}

	public void debugFloat(float number){
		Debug.Log (number);
	}
}
