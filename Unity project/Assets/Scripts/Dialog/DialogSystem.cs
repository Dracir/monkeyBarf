using UnityEngine;
using System.Collections;

public class DialogSystem : GuiScript {

	public Font font;
	private CharacterDialog character;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startDialogWith(CharacterDialog character){
		this.character = character;
	}

	void OnGUI() {
		if (character == null) return;
		GUIStyle style = generateFont (12, font, Color.white);
		drawTextRightJustified (new Vector2 (50,50), character.brushOff, style);
	}

}
