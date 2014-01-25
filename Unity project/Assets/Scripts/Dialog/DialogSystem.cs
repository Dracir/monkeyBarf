using UnityEngine;
using System.Collections;

public class DialogSystem : GuiScript {

	public Font font;
	public Texture2D dialogBox;
	public Vector2 dialogBoxRatio = new Vector2(0.9f,0.35f);
	public float dialogBoxYOffsetRatioOfScreen = 0.05f;
	public float characterWritingSpeed = 4.0f;

	
	private CharacterDialog character;
	public SlowTextWriter textWriter;

	void Start () {
	
	}
	
	void Update () {
		
	}

	public void startDialogWith(CharacterDialog character){
		this.character = character;
		this.textWriter = new SlowTextWriter (character.brushOff, characterWritingSpeed);
	}

	void OnGUI() {
		if (character == null) return;
		GUIStyle style = generateFont (18, font, Color.white);

		int xOffset = (int) (Screen.width * (1.0 - dialogBoxRatio.x) / 2);
		int yOffset = (int) (Screen.height * (1.0 - (dialogBoxRatio.y + dialogBoxYOffsetRatioOfScreen)));
		GUI.DrawTexture (new Rect(xOffset, yOffset, Screen.width *dialogBoxRatio.x,Screen.height * dialogBoxRatio.y),dialogBox);
		if (this.textWriter != null) {
			int boxX = (int)(Screen.width * dialogBoxRatio.x - 20);
       		int boxY = (int)(Screen.height * dialogBoxRatio.y - 20);
			drawTextLeftJustified (new Vector2 (xOffset+15,yOffset+10), this.textWriter.getText(), style, new Vector2(boxX,boxY) );		
		}

	}

}
