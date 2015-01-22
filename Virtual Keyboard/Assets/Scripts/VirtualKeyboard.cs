using UnityEngine;
using System.Collections;

[RequireComponent(typeof(InteractionPanel))]
public class VirtualKeyboard : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Something hit the keyboard");
	}

}

