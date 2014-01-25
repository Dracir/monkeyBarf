using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour {


	protected GUIStyle generateFont(int fontsize, Font font, Color color){
		GUIStyle style = new GUIStyle ();
		style.fontSize = fontsize;
		style.font = font;
		style.normal.textColor = color;
		return style;
	}

	protected void drawTextCentered(Vector2 p, string text, GUIStyle style){
		Vector2 textSize = style.CalcSize(new GUIContent(text));
		Rect r = new Rect (p.x - textSize.x/2, p.y - textSize.y/2, textSize.x, textSize.y);
		GUI.Box(r,text,style);
	}
	
	protected void drawTextLeftJustified(Vector2 p, string text, GUIStyle style){
		Vector2 textSize = style.CalcSize(new GUIContent(text));
		Rect r = new Rect (p.x, p.y, textSize.x, textSize.y);
		GUI.Box(r,text,style);
	}
	
	protected void drawTextLeftJustified(Vector2 p, string text, GUIStyle style, Vector2 dimension){
		Vector2 textSize = style.CalcSize(new GUIContent(text));
		style.wordWrap = true;
		Rect r = new Rect (p.x, p.y, dimension.x, dimension.y);
		GUI.Box(r,text,style);
	}
	
	protected void drawTextRightJustified(Vector2 p, string text, GUIStyle style){
		Vector2 textSize = style.CalcSize(new GUIContent(text));
		float x = p.x-textSize.x;
		Rect r = new Rect (x, p.y, textSize.x, textSize.y);
		GUI.Box(r,text,style);
	}

	protected Vector2 fixPosition(Vector2 position){
		float x = position.x >= 0 ? position.x : Screen.width + position.x;  
		float y = position.y >= 0 ? position.y : Screen.height + position.y;
		return new Vector2(x,y);
	}
}
