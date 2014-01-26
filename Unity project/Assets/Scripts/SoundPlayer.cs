using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour {
	
	public AudioClip beethoven;
	public AudioClip awfulSound;
	public AudioClip partySound;
	
	private AudioSource source;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		PlaySound("party");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void PlaySound(string param){
		if (param == "beethoven"){
			source.clip = beethoven;
			source.loop = true;
			source.Play ();
			Debug.Log ("I'm playing: " + source.isPlaying);
		}
		else if (param == "annoying"){
			source.clip = awfulSound;
			source.loop = true;
			source.Play ();
		}
		else if(param == "party"){
			source.clip = partySound;
			source.loop = true;
			source.Play ();
		}
	}
}
