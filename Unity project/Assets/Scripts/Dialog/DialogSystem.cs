using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogSystem : GuiScript {

	public Vector2 textOffset = new Vector2 (15, 15);
	public Font font;
	public Texture2D dialogBox;
	public Texture2D choiceUnderlay;
	public Vector2 dialogBoxRatio = new Vector2(0.9f,0.35f);
	public float dialogBoxYOffsetRatioOfScreen = 0.05f;
	public float characterWritingSpeed = 4.0f;
	
	private GUIStyle textStyle;
	
	public CharacterDialog character;
	public SlowTextWriter textWriter;


	private List<MouseRegion> questionMouseRegion;
	private bool exitOnClick = false;
	private int selectedAnswerIndex = -1;
	private bool clicked = false;

	private ShotCaller shotCaller;
	private PlayerControler playerControler;
	private AdultGroupControler adultGroupControler;

	void Start () {
		questionMouseRegion = new List<MouseRegion> ();
		textStyle = generateFont (18, font, Color.black);
		shotCaller = (ShotCaller) GameObject.FindGameObjectWithTag ("TheGame").GetComponent<ShotCaller> ();
		adultGroupControler = (AdultGroupControler) GameObject.FindGameObjectWithTag ("TheGame").GetComponent<AdultGroupControler> ();
		playerControler = (PlayerControler) GameObject.FindGameObjectWithTag ("ThePlayer").GetComponent<PlayerControler> ();
	}
	
	void Update () {

		bool shouldExit = false;
		if (questionMouseRegion.Count > 0) {
			selectedAnswerIndex = -1;
			int index = 0;
			int mouseX = (int)Input.mousePosition.x;
			int mouseY = Screen.height - (int)Input.mousePosition.y;

			Dialog next = null;
			foreach(MouseRegion mr in questionMouseRegion){
				if(mr.zone.Contains(new Vector2(mouseX, mouseY))){
					selectedAnswerIndex = index;
					if(Input.GetMouseButtonDown(0)){
						clicked = true;
					}
					if(Input.GetMouseButtonUp(0)){
						if(clicked){
							clicked = false;
							shouldExit = true;
							next = mr.nextDialog;
							break;
						}
					}
				}
				index++;
			}
			if(shouldExit){
				switchTo(next);
			}
		}
		if (exitOnClick) {
			if(!clicked && Input.GetMouseButtonDown (0)){
				clicked = true;
			}else if(clicked && Input.GetMouseButtonUp (0)){
				exit();
			}
		}
	}
	
	public void exit (){
		character = null;
		textWriter = null;
		exitOnClick = false;
		clicked = false;
		playerControler.stopFixing ();
	}
	public void switchTo(Dialog nextDialog){
		questionMouseRegion.Clear ();
		selectedAnswerIndex = -1;
		if (nextDialog == null) {
			exit();
		} else if (nextDialog is SimpleResponse) {
			SimpleResponse simpleResponse = (SimpleResponse) nextDialog;
			this.textWriter = new SlowTextWriter (simpleResponse.text, characterWritingSpeed);
			exitOnClick = true;
		} else if(nextDialog is Question){
			doQuestion((Question) nextDialog);
		} else if(nextDialog is Activation){
			doActivation((Activation) nextDialog);
		} else if(nextDialog is ScriptCall){
			doScriptCall((ScriptCall) nextDialog);
		}  else if(nextDialog is Multiple){
			doMultiple((Multiple) nextDialog);
		} else {
			Debug.Log(nextDialog.GetType().Name);
		}
	}
	private void doMultiple(Multiple multiple){
		foreach(Dialog d in multiple.dialogs){
			if(d is Activation){
				Activation a = (Activation) d;
				adultGroupControler.activateTag (a.tag);
			} else if(d is ScriptCall){
				ScriptCall s = (ScriptCall) d;
				shotCaller.execute (s.script, s.tag, s.param);
			}
		}
		if (!multiple.text.Equals ("")) {
			this.textWriter = new SlowTextWriter (multiple.text, characterWritingSpeed);
			exitOnClick = true;
		} else {
			switchTo(null);
		}
	}

	private void doScriptCall(ScriptCall script){
		shotCaller.execute (script.script, script.tag,script.param);
		switchTo(script.nextDialog);
	}

	private void doActivation(Activation activation){
		adultGroupControler.activateTag (activation.tag);
		switchTo(activation.nextDialog);
	}

	private void doQuestion(Question question){
		string text = "";
		Vector2 offset = getBoxTopLeftLocation ();
		int xOffset = (int) (offset.x + textOffset.x);
		int lineHeigh = (int)( getTextSize(textStyle, "T").y );
		int yOffset = (int) (offset.y + textOffset.y + 30 + lineHeigh);
		int answerIndex = 0;
		
		questionMouseRegion.Clear();
		text += question.questionText + "\n";
		foreach(Answer answer in question.answers){
			int lineWidth = (int)( getTextSize(textStyle, answer.text).x );
			MouseRegion mr = new MouseRegion(new Rect(xOffset, yOffset  + lineHeigh * answerIndex,lineWidth,lineHeigh),answer.nextDialog);
			answerIndex++;
			questionMouseRegion.Add(mr);
			text += answer.text + "\n";
		}
		
		this.textWriter = new SlowTextWriter (text, characterWritingSpeed);
	}
	
	public void startDialogWith(CharacterDialog character){
		this.character = character;
		Transform[] tgroup = character.transform.GetComponentsInChildren<Transform> ();
		foreach (Transform t in tgroup) {
			if(t.name.Equals("Control_Head")){
				playerControler.fix (t);
			}

		}
		
		if (!character.hasActiveOpenner()) {
			string text = "";
			text += character.brushOff;
			this.textWriter = new SlowTextWriter (text, characterWritingSpeed);
		} else {
			
			string text = "";
			Vector2 offset = getBoxTopLeftLocation ();
			int xOffset = (int) (offset.x + textOffset.x);
			int yOffset = (int) (offset.y + textOffset.y + 30);
			int lineHeigh = (int)( getTextSize(textStyle, "T").y );
			int answerIndex = 0;

			questionMouseRegion.Clear();
			foreach(Openner opener in character.getActiveOpenner()){
				int lineWidth = (int)( getTextSize(textStyle, opener.text).x );
				MouseRegion mr = new MouseRegion(new Rect(xOffset, yOffset  + lineHeigh * answerIndex,lineWidth,lineHeigh),opener.nextDialog);
				answerIndex++;
				questionMouseRegion.Add(mr);
				text += opener.text + "\n";
			}

			this.textWriter = new SlowTextWriter (text, characterWritingSpeed);
		}

	}

	void OnGUI() {
		if (character == null) return;
		GUIStyle styleName = generateFont (25, font, Color.white);

		Vector2 offset = getBoxTopLeftLocation ();
		int xOffset = (int) offset.x;
		int yOffset = (int) offset.y;

		GUI.DrawTexture (new Rect(xOffset, yOffset, Screen.width *dialogBoxRatio.x,Screen.height * dialogBoxRatio.y),dialogBox);
		drawTextLeftJustified (new Vector2 (xOffset+textOffset.x,yOffset+textOffset.y), this.character.name, styleName);
		if (this.textWriter != null) {
			int boxWidth = (int)(Screen.width * dialogBoxRatio.x - 20);
       		int boxHeight = (int)(Screen.height * dialogBoxRatio.y - 20);

			if(selectedAnswerIndex != -1){
				Rect zone = questionMouseRegion[selectedAnswerIndex].zone;
				int answerY = (int) (yOffset +textOffset.y + 30 + zone.height * selectedAnswerIndex);
				GUI.DrawTexture (new Rect(zone.xMin, zone.yMin, zone.width,zone.height),choiceUnderlay);
			}
			drawTextLeftJustified (new Vector2 (xOffset+textOffset.x,yOffset+textOffset.y + 30), this.textWriter.getText(), textStyle, new Vector2(boxWidth,boxHeight) );		
		}

	}

	public Vector2 getBoxTopLeftLocation(){
		int xOffset = (int) (Screen.width * (1.0 - dialogBoxRatio.x) / 2);
		int yOffset = (int) (Screen.height * (1.0 - (dialogBoxRatio.y + dialogBoxYOffsetRatioOfScreen)));

		return new Vector2 (xOffset, yOffset);
	}

	private class MouseRegion{
		public Rect zone;
		public Dialog nextDialog;

		public MouseRegion(Rect zone, Dialog nextDialog){
			this.zone = zone;
			this.nextDialog = nextDialog;
		}
	}
}
