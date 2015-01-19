using UnityEngine;
using System.Collections;

public class InteractionPanel : MonoBehaviour
{
	public Collider[] collisionExclusionsList;

	private BoxCollider[] childColliders;

	// Use this for initialization
	void Start ()
	{
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

