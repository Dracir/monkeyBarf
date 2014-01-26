using UnityEngine;
using System.Collections;

public class SlowTextWriter {

	string fullText;
	float currentLenght;
	float speed;

	public SlowTextWriter(string fullText, float speed){
		this.fullText = fullText;
		this.currentLenght = 0;
		this.speed = speed;
	}

	public string getText(){
		currentLenght += speed * Time.deltaTime;	
		if (currentLenght >= fullText.Length) {
			currentLenght = fullText.Length;
		}

		return fullText.Substring (0, (int)currentLenght);
	}
}
