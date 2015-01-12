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
}

