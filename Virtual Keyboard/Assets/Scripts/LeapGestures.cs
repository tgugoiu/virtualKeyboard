using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class LeapGestures : MonoBehaviour {

	private Controller leapController;
	private int gestureId;

	GameObject[] interactionPanels;
	private int interactionPanel = 0;

	public delegate void CircularGestureAction(object sender, System.EventArgs e);
	public static event CircularGestureAction CircularGestureTriggered;

	void Awake () {
		leapController = new Controller ();
	}
	// Use this for initialization
	void Start () {
		interactionPanels = GameObject.FindGameObjectsWithTag("InteractionPanel");
		foreach(GameObject interactionPanel in interactionPanels) {
			// interactionPanel.SetActive(false);
		}

		leapController.EnableGesture (Leap.Gesture.GestureType.TYPECIRCLE);
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = leapController.Frame ();
		GestureList gestures = frame.Gestures();

		foreach (Gesture gesture in gestures) {
			if( gesture.State.Equals(Gesture.GestureState.STATESTOP) ) {
				OnCircularGestureCompleted(this, null);
			}
		}
	}

	private void OnCircularGestureCompleted(object sender, System.EventArgs e) {
		switchInputType();
		if (CircularGestureTriggered != null) {
			CircularGestureTriggered(sender, e);
			Debug.Log("Circular gesture");
		}
	}

	void switchInputType() {
		interactionPanels[interactionPanel%2].SetActive(false);

		interactionPanel++;

		interactionPanels[interactionPanel%2].SetActive(true);
	}
}
