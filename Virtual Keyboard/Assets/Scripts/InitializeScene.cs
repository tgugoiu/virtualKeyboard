using UnityEngine;
using System.Collections;

public class InitializeScene : MonoBehaviour {
	void Awake() {
		Debug.Log ("up and running");
		
		string[] keys = {"`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=",
			"q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "\\",
			"a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "'",
			"z", "x", "c", "v", "b", "n", "m", ",", ".", "/",
			"space"};
		
		string[] row1Keys = {"`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "="};
		string[] row2Keys = {"q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "\\"};
		string[] row3Keys = {"a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "'"};
		string[] row4Keys = {"z", "x", "c", "v", "b", "n", "m", ",", ".", "/"};
		string[] row5Keys = {"space"};

		
		GameObject user = GameObject.Find ("User");
		GameObject keyboardObj = new GameObject ();
		keyboardObj.name = "ScriptKeyboard";
		keyboardObj.AddComponent ("KeyboardComponent");
		keyboardObj.transform.parent = user.transform;
		keyboardObj.transform.localPosition = new Vector3 (0, -1.8f, 0);
		
		GameObject keyboardRow1 = new GameObject ();
		keyboardRow1.transform.parent = keyboardObj.transform;
		keyboardRow1.transform.localPosition = new Vector3 (0, 0, 0);
		keyboardRow1.AddComponent ("KeyboardRowComponent");
		KeyboardRowComponent rowComponent = keyboardRow1.GetComponent<KeyboardRowComponent> ();
		rowComponent.setGameObject(keyboardRow1);
		rowComponent.setKeys (row1Keys);

		GameObject keyboardRow2 = new GameObject ();
		keyboardRow2.transform.parent = keyboardObj.transform;
		keyboardRow2.transform.localPosition = new Vector3 (-1, 0, -1);
		keyboardRow2.AddComponent ("KeyboardRowComponent");
		KeyboardRowComponent rowComponent2 = keyboardRow2.GetComponent<KeyboardRowComponent> ();
		rowComponent2.setGameObject(keyboardRow2);
		rowComponent2.setKeys (row2Keys);

		GameObject keyboardRow3 = new GameObject ();
		keyboardRow3.transform.parent = keyboardObj.transform;
		keyboardRow3.transform.localPosition = new Vector3 (-2, 0, -1.5f);
		keyboardRow3.AddComponent ("KeyboardRowComponent");
		KeyboardRowComponent rowComponent3 = keyboardRow3.GetComponent<KeyboardRowComponent> ();
		rowComponent3.setGameObject(keyboardRow3);
		rowComponent3.setKeys (row3Keys);

		GameObject keyboardRow4 = new GameObject ();
		keyboardRow4.transform.parent = keyboardObj.transform;
		keyboardRow4.transform.localPosition = new Vector3 (-3, 0, -2);
		keyboardRow4.AddComponent ("KeyboardRowComponent");
		KeyboardRowComponent rowComponent4 = keyboardRow4.GetComponent<KeyboardRowComponent> ();
		rowComponent4.setGameObject(keyboardRow4);
		rowComponent4.setKeys (row4Keys);

		GameObject keyboardRow5 = new GameObject ();
		keyboardRow5.transform.parent = keyboardObj.transform;
		keyboardRow5.transform.localPosition = new Vector3 (-4, 0, 0);
		keyboardRow5.AddComponent ("KeyboardRowComponent");
		KeyboardRowComponent rowComponent5 = keyboardRow5.GetComponent<KeyboardRowComponent> ();
		rowComponent5.setGameObject(keyboardRow5);
		rowComponent5.setKeys (row5Keys);
		
		KeyboardComponent keyboard = keyboardObj.GetComponent<KeyboardComponent> ();
		
		user.AddComponent<MovementScript> ();
	}
}