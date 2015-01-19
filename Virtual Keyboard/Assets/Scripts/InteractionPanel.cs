using UnityEngine;
using System.Collections;

public class InteractionPanel : MonoBehaviour
{
	public Collider[] collisionExclusionsList;
		// Use this for initialization
	private BoxCollider[] childColliders;
	void Start ()
	{
		// collisionExclusionsList[collisionExclusionsList.Length] = user.collider;
		// gameObject.GetComponentsInChildren (BoxCollider);
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
}

