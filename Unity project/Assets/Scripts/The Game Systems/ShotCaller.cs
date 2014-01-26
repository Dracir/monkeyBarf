using UnityEngine;
using System.Collections;

public class ShotCaller : MonoBehaviour {

	private AdultGroupControler adultGroupControler;
	private PlayerControler playerControler;

	private GameObject[] adults;
	void Start () {
		adultGroupControler = (AdultGroupControler)this.gameObject.GetComponent<AdultGroupControler> ();
		playerControler = (PlayerControler)GameObject.FindGameObjectWithTag ("ThePlayer").GetComponent<PlayerControler> ();
		
		Animator[] animators = FindObjectsOfType(typeof(Animator)) as Animator[];
		foreach (Animator item in animators) {
			item.playbackTime = Random.Range(0, 6f);
			//item.Play();
		}
	adults = GameObject.FindGameObjectsWithTag("Adult");
		
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
		}else if (functionName.Equals ("superStrength")) {
			Furniture[] furniture = FindObjectsOfType(typeof(Furniture)) as Furniture[];
			foreach (Furniture item in furniture) {
				item.AddRigidbody();
			}
		}else if (functionName.Equals ("changeModels")){
			
			if (tag == "furniture"){
				Furniture[] furniture = FindObjectsOfType(typeof(Furniture)) as Furniture[];
				 foreach (Furniture item in furniture) {
					item.ChangeModel(param);
				 }
			}
			else{
				GameObject[] adults = GameObject.FindGameObjectsWithTag("Adult");
				
				foreach (GameObject adult in adults){
					foreach(Transform tr in adult.GetComponentsInChildren<Transform>()){
						if (tr.name == tag){
							tr.gameObject.SetActive(false);
						}
						if (tr.name == param){
							tr.gameObject.SetActive(true);
						}
					}
				}
				/*GameObject toDisable;
				do{
					toDisable = GameObject.Find (tag);
					if (toDisable){
						toDisable.renderer.enabled = false;
						toDisable.name = "";
					}
				}
				while(toDisable != null);
				
				GameObject toEnable;
				
				do{
					toEnable = GameObject.Find (param);
					if (toEnable){
						toEnable.renderer.enabled = true;
						toEnable.name = "";
					}
				}
				while (toEnable != null);*/
			}
		}else if (functionName.Equals ("changeTextures")){
			GameObject[] toChange = GameObject.FindGameObjectsWithTag(tag);
			foreach (GameObject item in toChange) {
				//item.renderer.material.mainTexture = Resources.Load ("Textures/" + param) as Texture;
				//HACK I DON'T KNOW WHICH ONE OF THESE IS CORRECT TO DO AT THIS POINT
				item.renderer.material = Resources.Load ("Materials/" + param) as Material;
			}
		}else if (functionName.Equals("particlesFromSky")){
			GameObject.Find (param).SetActive(true);
		}else if (functionName.Equals("spawn")){
			Spawner[] spawners = FindObjectsOfType (typeof(Spawner)) as Spawner[];
			foreach(Spawner spawner in spawners){
				spawner.Spawn(param);
			}
		}else if (functionName.Equals ("vibrate")){
			if (tag == "adult"){
				GameObject[] adults = GameObject.FindGameObjectsWithTag("Adult");
				foreach(GameObject adult in adults){
					adult.AddComponent<Vibrator>();
				}
			}
			else if (tag == "arm"){
				GameObject[] adults = GameObject.FindGameObjectsWithTag("Adult");
				foreach(GameObject adult in adults){
					foreach(Transform tr in adult.GetComponentsInChildren<Transform>()){
						if (tr.name.Contains("Arm")){
							tr.gameObject.AddComponent<Vibrator>();
						}
					}
				}
			}
		}else if (functionName.Equals ("playSound")){
			SoundPlayer[] players = FindObjectsOfType(typeof(SoundPlayer)) as SoundPlayer[];
			
			foreach (SoundPlayer player in players){
				player.PlaySound(param);
			}
		}else if (functionName.Equals("flickerLights")){
			gameObject.AddComponent<LightFlicker>();
		}else if (functionName.Equals ("disappear")){
			if (param == "all"){
				GameObject[] adults = GameObject.FindGameObjectsWithTag("Adult");
				for (int i = 0; i < adults.Length; i++) {
					Destroy(adults[i]);
				}
			}
			Destroy(GameObject.Find(param));
		}else if (functionName.Equals ("clone")){
			CloneOrDestroy[] cloners = FindObjectsOfType(typeof(CloneOrDestroy)) as CloneOrDestroy[];
			foreach (CloneOrDestroy item in cloners) {
				item.SendMessage("Clone");
			}
		}else if (functionName.Equals("addToAdultModels")){
			Debug.Log ("yeah'");
		}
	}

	public void debugFloat(float number){
		Debug.Log (number);
	}
}
