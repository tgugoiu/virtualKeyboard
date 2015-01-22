using UnityEngine;
using System.Collections;

public class KeyActivator : MonoBehaviour
{
	public delegate void KeyLeapPressAction(string keyId, Collision collision);
	public static event KeyLeapPressAction OnKeyLeapPressed;

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
			setColor(activeColor);
		} else if (Input.GetKeyUp (keyId)) 
		{
			setColor(baseColor);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Plane")
			return;
		OnKeyLeapPressed (keyId, collision);
		Debug.Log ("Something hit the " + keyId + " key");
		setColor(activeColor);
	}

	void OnCollisionExit(Collision collision) {
		setColor(baseColor);
	}

	void setColor(Color color) {
		textMesh.color = color;
	}


}

