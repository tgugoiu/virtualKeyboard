using UnityEngine;
using System.Collections;

public class KeyActivator : MonoBehaviour
{
	public Color activeColor;
	public string keyId;

	private TextMesh textMesh;
	private Color baseColor;
	// Use this for initialization
	void Start ()
	{
		Transform children = transform.Find ("Key_Text");
		if (children)
		{
			textMesh = children.GetComponent<TextMesh>();
			baseColor = textMesh.color;
		}

	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (keyId)) {
			textMesh.color = activeColor;
		} else if (Input.GetKeyUp (keyId)) 
		{
			textMesh.color = baseColor;
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Plane")
			return;
		Debug.Log ("Something hit the " + keyId + " key");
		textMesh.color = activeColor;
	}

	void OnCollisionExit(Collision collision) {
		textMesh.color = baseColor;
	}


}

