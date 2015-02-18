using UnityEngine;
using System.Collections;
using Leap;

public class ItemManipulator : MonoBehaviour
{
	public delegate void KeyLeapPressAction(string keyId);
	public delegate void KeyLeapReleaseAction(string keyId);
	public static event KeyLeapPressAction OnKeyLeapPressed;
	public static event KeyLeapReleaseAction OnKeyLeapReleased;

	private TextMesh textMesh;
	private Color baseColor;
	private Controller controller;

	private bool trackingActive = false;

	// Use this for initialization
	void Start ()
	{
		controller = new Controller ();
	}

	// Update is called once per frame
	void Update ()
	{
		translateHand ();
		rotateHand();
	}

	void OnCollisionEnter(Collision collision) {
		trackingActive = true;
		setColor (Color.blue);
	}

	void translateHand() {
		if (!trackingActive) return;
		Frame currentFrame = controller.Frame ();
		Frame oldFrame = controller.Frame (1);

		// Translation
		Vector translation = currentFrame.Translation (oldFrame);
		Vector3 unityTranslationVector = calculateUnityTranslationVector (translation);
		this.transform.Translate (unityTranslationVector);
	}

	void rotateHand() {
		Frame currentFrame = controller.Frame ();
		Frame prevFrame = controller.Frame (5);
		float leapRotationAngle = currentFrame.RotationAngle(prevFrame, Vector.YAxis); 

		float unityRotationAngle = leapRotationAngle * (180f/Mathf.PI);
		this.transform.Rotate(new Vector3(0f, unityRotationAngle, 0f));
	}

	Vector3 calculateUnityTranslationVector(Vector vec) {
		float movementIncrementX = vec.x != 0 && Mathf.Abs(vec.x) > 5 ? 0.01f : 0;
		float movementIncrementY = vec.y != 0 && Mathf.Abs (vec.y) > 5 ? 0.01f : 0;
		float movementIncrementZ = vec.z != 0 && Mathf.Abs(vec.z) > 5 ? 0.01f : 0;
		float xDirection = vec.x >= 0 ? 1f : -1f;
		float yDirection = vec.y >= 0 ? 1f : -1f;
		float zDirection = vec.z >= 0 ? 1f : -1f;

		Vector3 unityVector = new Vector3 (xDirection * movementIncrementX,
		                                  yDirection * movementIncrementY,
		                                  zDirection * movementIncrementZ);

		return unityVector;
	}

	float calculateUnityRotationAngle(float leapRotationAngle) {
		return 0f;
	}

	void OnCollisionExit(Collision collision) {
	}

	void setColor(Color color) {
	}


}

