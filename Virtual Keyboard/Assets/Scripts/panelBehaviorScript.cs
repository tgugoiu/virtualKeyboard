using UnityEngine;
using System.Collections;

public class panelBehaviorScript : MonoBehaviour {

	GameObject user;
	public GameObject forceField;
	public string panelRequiredText;
	public float interactionRange;
	TextMesh promptTextMesh;
	TextMesh inputTextMesh;
	// var panelText;

	// Use this for initialization
	void Start () {
		user = GameObject.Find ("User");
		Transform prompts  = transform.Find("Prompt");
		Transform inputs  = transform.Find("Input");

		if (prompts) {
			promptTextMesh = prompts.GetComponent<TextMesh>();
		}
		if (inputs) {
			inputTextMesh = inputs.GetComponent<TextMesh>();
		}

		promptTextMesh.text = panelRequiredText;
	}
	
	// Update is called once per frame
	void Update () {
		float distance =  + Mathf.Sqrt(Mathf.Pow ((user.transform.position.x - transform.position.x), 2) + Mathf.Pow((user.transform.position.z - transform.position.z), 2));

		if (distance <= interactionRange) {
			Debug.Log ("In Panel Range");
			string currentText = inputTextMesh.text;
			int currentTextLength = currentText.Length;
			char nextChar;

			if( currentTextLength >= panelRequiredText.Length ) {
				return;
			}

			if( currentTextLength > 0 ) {
				int nextPos = currentText.Length;
				nextChar = panelRequiredText[nextPos];
			}
			else {
				nextChar = panelRequiredText[0];
			}

			string currentInput = Input.inputString;
			if( currentInput.Length > 0 && currentInput[0].Equals(nextChar) ) {
				inputTextMesh.text = currentText + nextChar;
			}

			if( inputTextMesh.text.Equals(panelRequiredText) ) {
				forceField.SetActive(!forceField.activeSelf);
				inputTextMesh.text = "";
			}
		}
	}
}
