using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class DialogLoader {
	
	private XmlTextReader reader;

	private DialogLoader(TextAsset dialogFile,CharacterDialog characterDialog){
		reader = new XmlTextReader(new StringReader(dialogFile.text));
		
		while(reader.Read()){
			if(reader.Name.Equals("brush-off")){
				characterDialog.brushOff = getReaderAttribute("text");
			}else if(reader.Name.Equals("opener")){
				characterDialog.openners.Add (readOpenner());
			}else if(reader.Name.Equals("dialog") && reader.GetAttribute("name") != null){
				characterDialog.characterName = reader.GetAttribute("name");
			}
		}
	}

	private Openner readOpenner(){
		Openner openner = new Openner();
		openner.tag = reader.GetAttribute("tag");
		openner.text = reader.GetAttribute("id");
		openner.active = openner.tag.Equals ("");

		while (reader.Read()) {
			if(reader.Name.Equals("opener")){
				break;
			} else if(openner.nextDialog == null){
				openner.nextDialog = readDialog();
			}
		}

		return openner;
	}
	
	public Dialog readNextDialog(){
		if(reader.Read ()){
			return readDialog();
		}
		
		return null;
	}

	public Dialog readDialog(){
		if (reader.Name.Equals ("response")) {
			return readResponse ();
		} else if (reader.Name.Equals ("activate")) {
			return readActivation ();
		} else if (reader.Name.Equals ("script")) {
			return readScript ();
		} else if (reader.Name.Equals ("question")) {
			return readQuestion ();
		} else if (reader.Name.Equals ("multiple")) {
			return readMultiple ();
		} else {
			return null;		
		}
		

	}

	private Dialog readMultiple(){
		Multiple multiple = new Multiple(getReaderAttribute("text"));
		while (reader.Read()) {
			if(reader.Name.Equals("multiple")){
				break;
			} else {
				multiple.dialogs.Add(readDialog());
			}
		}
		return multiple;
	}

	private Dialog readQuestion(){
		Question question = new Question(getReaderAttribute("text"));
		while (reader.Read()) {
			if(reader.Name.Equals("question")){
				break;
			} else if(reader.Name.Equals("answer")){
				if(reader.GetAttribute("text") != null){
					Answer answer = readAnswer();
					question.answers.Add(answer);
				}
			} else if(reader.Name.Equals("")){

			} else {
				Debug.LogError("erreur dans le xml ! une 'question' doit etre compose de 'answer' seulement at line " + reader.LineNumber);
			}
		}
		return question;
	}

	public Answer readAnswer(){
		Answer answer = new Answer(getReaderAttribute("text"));
		reader.Read ();
		answer.nextDialog = readNextDialog ();
		return answer;
	}

	public SimpleResponse readResponse(){
		SimpleResponse reponse = new SimpleResponse(getReaderAttribute("text"));
		reader.Read ();
		return reponse;
	}
	
	public Activation readActivation(){
		Activation activation = new Activation(reader.GetAttribute("tag"));
		reader.Read ();
		return activation;
	}
	
	public ScriptCall readScript(){
		ScriptCall scriptCall = new ScriptCall(reader.GetAttribute("function"),reader.GetAttribute("param"));
		reader.Read ();
		return scriptCall;
	}

	public string getReaderAttribute(string attribut){
		string text = reader.GetAttribute (attribut);
		if (text != null) {
			return text.Replace("\\n","\n");
		}
		return null;
	}
	
	public static void Load(TextAsset dialogFile,CharacterDialog characterDialog){
		new DialogLoader (dialogFile,characterDialog);
	}
}
