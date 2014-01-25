using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Question : Dialog {

	public string questionText;

	public List<Answer> answers;

	public Question(string questionText){
		this.questionText = questionText;
		this.answers = new List<Answer> ();
	}

}
