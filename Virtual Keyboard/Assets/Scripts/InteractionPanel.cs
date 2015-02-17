using UnityEngine;
using System.Collections;

public class InteractionPanel : MonoBehaviour
{
	public Collider[] collisionExclusionsList;

	public GameObject user;

	private OVRPlayerController playerController;
	private BoxCollider[] childColliders;

	// Use this for initialization
	void Start ()
	{
		//Debug.Log ( user.get
		playerController = user.GetComponent<OVRPlayerController>() as OVRPlayerController;
		Debug.Log (playerController);
		KeyActivator.OnKeyLeapPressed += onKeyLeapPressed;
		KeyActivator.OnKeyLeapReleased += onKeyLeapReleased;
		childColliders = gameObject.GetComponentsInChildren<BoxCollider>() as BoxCollider[];
		foreach( Collider childCollider in childColliders ) {
			if( childCollider.enabled == true ) {
				foreach( Collider collisonExcluded in collisionExclusionsList ) {
					Physics.IgnoreCollision( childCollider, collisonExcluded );
				}
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void onCollisionEnter(Collision collision) {
		Debug.Log ("Something hit the keyboard");
	}

	void onKeyLeapReleased(string keyId) {
		string upperKeyId = keyId.ToUpper ();
		if (upperKeyId.Equals (KeyCode.W.ToString ())) {
			playerController.moveForward = false;
		} else if (upperKeyId.Equals (KeyCode.A.ToString ())) {
			playerController.moveLeft = false;
		} else if ( upperKeyId.Equals (KeyCode.D.ToString())) {
			playerController.moveRight = false;
		} else if ( upperKeyId.Equals (KeyCode.S.ToString())) {
			playerController.moveBack = false;
		}
	}

	void onKeyLeapPressed(string keyId) {
		string upperKeyId = keyId.ToUpper ();
		if (upperKeyId.Equals (KeyCode.W.ToString ())) {
			playerController.moveForward = true;
		} else if (upperKeyId.Equals (KeyCode.A.ToString ())) {
			playerController.moveLeft = true;
		} else if ( upperKeyId.Equals (KeyCode.D.ToString())) {
			playerController.moveRight = true;
		} else if ( upperKeyId.Equals (KeyCode.S.ToString())) {
			playerController.moveBack = true;
		}
	}
}

