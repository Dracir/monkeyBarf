using UnityEngine;
using System.Collections;

public class AdultControler : MonoBehaviour {

	private CharacterDialog dialog;
	private GameObject overHeadNameGameObject;
	private TextMesh overHeadName;

	// Use this for initialization
	void Awake () {
		dialog = this.GetComponent<CharacterDialog> ();
		overHeadNameGameObject = this.gameObject.transform.FindChild ("CharacterName").gameObject;
		overHeadName = (TextMesh) overHeadNameGameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setName(string name){
		dialog.name = name;
		overHeadName.text = name;
	}

	public void showName(){
		overHeadNameGameObject.SetActive (true);
	}

	public void hideName(){
		overHeadNameGameObject.SetActive (false);
	}
}
