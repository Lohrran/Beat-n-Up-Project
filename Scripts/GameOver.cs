using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	private GUISkin newSkin;
	
	void Start()
	{
		newSkin = Resources.Load ("testSkin") as GUISkin;
		
	}
	
	void OnGUI()
	{
		GUI.skin = newSkin;
		
		const int buttonWidth = 200;
		const int buttonHeight = 50;
		int labelWidth = 500;
		int labelHeight = 100;
		
		GUI.Label (new Rect(Screen.width / 2 - labelWidth / 4, Screen.height / 5, labelWidth, labelHeight), "Game Over");
		
		if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, Screen.height / 1.5f - buttonHeight / 2, buttonWidth, buttonHeight), "Try Again"))
		{
			Application.LoadLevel("Scene_test");
		}
		
	}
}
