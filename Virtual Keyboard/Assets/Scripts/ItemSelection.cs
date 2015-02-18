using UnityEngine;
using System.Collections;

public class ItemSelection : MonoBehaviour {

	public delegate void ItemOnSelect(GameObject selectedItem);
	public static event ItemOnSelect OnItemSelected;

	// Use this for initialization
	void Start () {
	
	}

	// public delegate void ItemOnSelect();
	// public static event ItemOnSelect OnItemSelected;
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		OnItemSelected(gameObject);
	}
}
