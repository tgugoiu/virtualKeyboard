using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class LeapGestureInit : MonoBehaviour {

	private Controller leapController;
	private int gestureId;

	public delegate void CircularGestureAction(object sender, System.EventArgs e);
	public static event CircularGestureAction CircularGestureTriggered;

	void Awake () {
		leapController = new Controller ();
	}
	// Use this for initialization
	void Start () {
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
		if (CircularGestureTriggered != null) {
			CircularGestureTriggered(sender, e);
		}
	}
}
