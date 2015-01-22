using UnityEngine;
using System.Collections;

[RequireComponent(typeof(InteractionPanel))]
public class VirtualKeyboard : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		KeyActivator.OnKeyLeapPressed += onKeyLeapPressed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Something hit the keyboard");
	}

	void onKeyLeapPressed(string keyId, Collision collision) {
		Debug.Log ("Received KeyLeapPressed event for " + keyId);
		Debug.Log ("Collision was with: " + collision.gameObject.name);
	}
}

